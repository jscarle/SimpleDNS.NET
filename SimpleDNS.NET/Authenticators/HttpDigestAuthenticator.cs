using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using RestSharp;
using RestSharp.Authenticators;

namespace SimpleDNS.Authenticators;

/// <summary>
/// Digest midleware for <see cref="IRestClient"/>.
/// </summary>
public class HttpDigestAuthenticator : IAuthenticator
{
    private readonly Dictionary<string, int> _nonceCount;
    private readonly string _username;
    private readonly string _password;

    /// <summary>
    /// Creates a new instance of <see cref="HttpDigestAuthenticator"/> class.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    public HttpDigestAuthenticator(string username, string password)
    {
        _nonceCount = new Dictionary<string, int>();

        _username = username;
        _password = password;
    }

    /// <inheritdoc cref="IAuthenticator" />.
    public void Authenticate(IRestClient client, IRestRequest request)
    {
        /*
        Documentation
        https://en.wikipedia.org/wiki/Digest_access_authentication
        https://httpwg.org/specs/rfc7616.html
        https://tools.ietf.org/html/rfc5987
        https://tools.ietf.org/html/rfc2617
        https://tools.ietf.org/html/rfc4234
        https://tools.ietf.org/html/rfc2069
        https://tools.ietf.org/html/rfc7616
        */

        // Save current authenticator
        var authenticator = client.Authenticator;

        // Unbind the authenticator
        client.Authenticator = null;

        // Execute the request
        var response = client.Execute(request);

        if (response.ResponseStatus == ResponseStatus.Error)
            throw new WebException(response.ErrorMessage, response.ErrorException);

        if (response.StatusCode != HttpStatusCode.Unauthorized)
            throw new WebException($"Received {response.StatusCode} {response.StatusDescription} when expecting 401 Unauthorized.", WebExceptionStatus.ProtocolError);

        // Rebind the authenticator
        client.Authenticator = authenticator;

        // Extract the WWW-Authentication headers
        var wwwAuthenticateHeaders = ExtractWwwAuthenticateHeaders(response);

        if (wwwAuthenticateHeaders.Count == 0)
            throw new WebException("The WWW-Authenticate header is missing.", WebExceptionStatus.ProtocolError);

        // Track nonce
        if (_nonceCount.ContainsKey(wwwAuthenticateHeaders[0].Nonce))
            _nonceCount[wwwAuthenticateHeaders[0].Nonce]++;
        else
            _nonceCount.Add(wwwAuthenticateHeaders[0].Nonce, 1);

        // Build the Authorization header
        var authorizationHeader = BuildAuthorizationHeader(client, request, response, wwwAuthenticateHeaders[0]);

        request.AddParameter(authorizationHeader.Name, authorizationHeader.Value, ParameterType.HttpHeader);
    }

    private static List<WwwAuthenticateHeader> ExtractWwwAuthenticateHeaders(IRestResponse response)
    {
        var wwwAuthenticateHeaders = new List<WwwAuthenticateHeader>();

        foreach (var header in response.Headers)
            if (header.Name == "WWW-Authenticate")
            {
                var headerValue = (string)header.Value;

                if (headerValue is null || !headerValue.StartsWith("Digest "))
                    break;

                if (headerValue.Length < 8)
                    throw new Exception("The WWW-Authenticate header is corrupt or missing data.");

                var wwwAuthenticateHeader = new WwwAuthenticateHeader
                {
                    Realm = ExtractParameterValue(headerValue, "realm", "\"([^\"]+)\""),
                    Domain = ExtractParameterValue(headerValue, "domain", "\"([^\"]+)\""),
                    Nonce = ExtractParameterValue(headerValue, "nonce", "\"([^\"]+)\""),
                    Opaque = ExtractParameterValue(headerValue, "opaque", "\"([^\"]+)\""),
                    Stale = ExtractParameterValue(headerValue, "stale", "(?i)\"?(true|false)\"?"),
                    Algorithm = ExtractParameterValue(headerValue, "algorithm", "\"?((?:SHA-256|SHA-512-256|MD5)(?:-sess)?)\"?"),
                    Qop = ExtractParameterValue(headerValue, "qop", "\"([^\"]+)\""),
                    Charset = ExtractParameterValue(headerValue, "charset", "\"?(UTF-8)\"?"),
                    UserHash = ExtractParameterValue(headerValue, "userhash", "\"?(true|false)\"?")
                };
                wwwAuthenticateHeaders.Add(wwwAuthenticateHeader);
            }

        return wwwAuthenticateHeaders;
    }

    private HttpHeader BuildAuthorizationHeader(IRestClient client, IRestRequest request, IRestResponse response, WwwAuthenticateHeader wwwAuthenticateHeader)
    {
        var uri = client.BuildUri(request).PathAndQuery;

        var cnonce = GenerateCnonce();

        var qop = "";
        foreach (var token in wwwAuthenticateHeader.Qop.Split(','))
        {
            switch (token.Trim())
            {
                case "auth":
                    qop = "auth";
                    break;
                case "auth-int":
                    qop = "auth-int";
                    break;
            }
        }

        string algorithm;
        string hash1;
        switch (wwwAuthenticateHeader.Algorithm)
        {
            default: //case "MD5":
                algorithm = "MD5";
                hash1 = Md5Hash($"{_username}:{wwwAuthenticateHeader.Realm}:{_password}");
                break;

            case "MD5-sess":
                algorithm = "MD5-sess";
                hash1 = Md5Hash($"{_username}:{wwwAuthenticateHeader.Realm}:{_password}");
                hash1 = Md5Hash($"{hash1}:{wwwAuthenticateHeader.Nonce}:{cnonce}");
                break;
        }

        string hash2;
        if (qop == "auth-int")
        {
            hash2 = Md5Hash(response.Content);
            hash2 = Md5Hash($"{request.Method}:{uri}:{hash2}");
        }
        else
        {
            hash2 = Md5Hash($"{request.Method}:{uri}");
        }

        var responseHash = Md5Hash(string.IsNullOrEmpty(qop) ? $"{hash1}:{wwwAuthenticateHeader.Nonce}:{hash2}" : $"{hash1}:{wwwAuthenticateHeader.Nonce}:{_nonceCount[wwwAuthenticateHeader.Nonce]:x8}:{cnonce}:{qop}:{hash2}");

        var headerValue = new List<string>
        {
            $"username=\"{_username}\"",
            $"realm=\"{wwwAuthenticateHeader.Realm}\"",
            $"uri=\"{uri}\"",
            $"algorithm={algorithm}",
            $"nonce=\"{wwwAuthenticateHeader.Nonce}\"",
            $"nc={_nonceCount[wwwAuthenticateHeader.Nonce]:x8}",
            $"cnonce=\"{cnonce}\"",
            $"response=\"{responseHash}\"",
            $"opaque=\"{wwwAuthenticateHeader.Opaque}\""
        };
        if (!string.IsNullOrEmpty(qop))
            headerValue.Add($"qop={qop}");

        return new HttpHeader("Authorization", $"Digest {string.Join(",", headerValue)}");
    }

    private static string ExtractParameterValue(string wwwAuthenticateHeader, string key, string pattern)
    {
        var value = "";

        var parameter = Regex.Match(wwwAuthenticateHeader, $"{key}={pattern}");
        if (parameter.Success)
            value = parameter.Groups[1].Value;

        return value;
    }

    private static string GenerateCnonce()
    {
        var random = new Random();

        var thirtyBits = (uint)random.Next(1 << 30);
        var twoBits = (uint)random.Next(1 << 2);
        var cnonce = (thirtyBits << 2) | twoBits;

        return cnonce.ToString("x8");
    }

    private static string Md5Hash(string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = MD5.Create().ComputeHash(inputBytes);
        var hash = new StringBuilder();
        foreach (var hashByte in hashBytes)
            hash.Append($"{hashByte:x2}");
        return hash.ToString();
    }

    private class WwwAuthenticateHeader
    {
        public string Realm { get; init; }
        public string Domain { get; init; }
        public string Nonce { get; init; }
        public string Opaque { get; init; }
        public string Stale { get; init; }
        public string Algorithm { get; init; }
        public string Qop { get; init; }
        public string Charset { get; init; }
        public string UserHash { get; init; }
    }
}