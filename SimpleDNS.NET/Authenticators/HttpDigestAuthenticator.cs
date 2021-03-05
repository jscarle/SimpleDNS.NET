using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using RestSharp;
using RestSharp.Authenticators;

namespace SimpleDNS.Authenticators
{
    /// <summary>
    /// Digest midleware for <see cref="IRestClient"/>.
    /// </summary>
    public class HttpDigestAuthenticator : IAuthenticator
    {
        private readonly Dictionary<string, int> NonceCount;
        private readonly string Username;
        private readonly string Password;

        /// <summary>
        /// Creates a new instance of <see cref="HttpDigestAuthenticator"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public HttpDigestAuthenticator(string username, string password)
        {
            NonceCount = new Dictionary<string, int>();

            Username = username;
            Password = password;
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
            IAuthenticator authenticator = client.Authenticator;

            // Unbind the authenticator
            client.Authenticator = null;

            // Execute the request
            IRestResponse response = client.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Error)
                throw new WebException(response.ErrorMessage, response.ErrorException);

            if (response.StatusCode != HttpStatusCode.Unauthorized)
                throw new WebException($"Received {response.StatusCode} {response.StatusDescription} when expecting 401 Unauthorized.", WebExceptionStatus.ProtocolError);

            // Rebind the authenticator
            client.Authenticator = authenticator;

            // Extract the WWW-Authentication headers
            List<WWWAuthenticateHeader> wwwAuthenticateHeaders = ExtractWWWAuthenticateHeaders(response);

            if (wwwAuthenticateHeaders.Count == 0)
                throw new WebException("The WWW-Authenticate header is missing.", WebExceptionStatus.ProtocolError);

            // Track nonce
            if (NonceCount.ContainsKey(wwwAuthenticateHeaders[0].Nonce))
                NonceCount[wwwAuthenticateHeaders[0].Nonce]++;
            else
                NonceCount.Add(wwwAuthenticateHeaders[0].Nonce, 1);

            // Build the Authorization header
            HttpHeader authorizationHeader = BuildAuthorizationHeader(client, request, response, wwwAuthenticateHeaders[0]);

            request.AddParameter(authorizationHeader.Name, authorizationHeader.Value, ParameterType.HttpHeader);
        }

        private static List<WWWAuthenticateHeader> ExtractWWWAuthenticateHeaders(IRestResponse response)
        {
            List<WWWAuthenticateHeader> wwwAuthenticateHeaders = new List<WWWAuthenticateHeader>();

            foreach (Parameter header in response.Headers)
                if (header.Name == "WWW-Authenticate")
                {
                    string headerValue = (string)header.Value;

                    if (!headerValue.StartsWith("Digest "))
                        break;

                    if (headerValue.Length < 8)
                        throw new Exception("The WWW-Authenticate header is corrupt or missing data.");

                    WWWAuthenticateHeader wwwAuthenticateHeader = new WWWAuthenticateHeader
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

        private HttpHeader BuildAuthorizationHeader(IRestClient client, IRestRequest request, IRestResponse response, WWWAuthenticateHeader wwwAuthenticateHeader)
        {
            string uri = client.BuildUri(request).PathAndQuery;

            string cnonce = GenerateCnonce();

            string qop = "";
            foreach (string token in wwwAuthenticateHeader.Qop.Split(','))
            {
                if (token.Trim() == "auth")
                {
                    qop = "auth";
                    break;
                }
                else if (token.Trim() == "auth-int")
                {
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
                    hash1 = MD5Hash($"{Username}:{wwwAuthenticateHeader.Realm}:{Password}");
                    break;

                case "MD5-sess":
                    algorithm = "MD5-sess";
                    hash1 = MD5Hash($"{Username}:{wwwAuthenticateHeader.Realm}:{Password}");
                    hash1 = MD5Hash($"{hash1}:{wwwAuthenticateHeader.Nonce}:{cnonce}");
                    break;
            }

            string hash2;
            if (qop == "auth-int")
            {
                hash2 = MD5Hash(response.Content);
                hash2 = MD5Hash($"{request.Method}:{uri}:{hash2}");
            }
            else
            {
                hash2 = MD5Hash($"{request.Method}:{uri}");
            }

            string responseHash;
            if (String.IsNullOrEmpty(qop))
                responseHash = MD5Hash($"{hash1}:{wwwAuthenticateHeader.Nonce}:{hash2}");
            else
                responseHash = MD5Hash($"{hash1}:{wwwAuthenticateHeader.Nonce}:{NonceCount[wwwAuthenticateHeader.Nonce]:x8}:{cnonce}:{qop}:{hash2}");

            List<string> headerValue = new List<string>();
            headerValue.Add($"username=\"{Username}\"");
            headerValue.Add($"realm=\"{wwwAuthenticateHeader.Realm}\"");
            headerValue.Add($"uri=\"{uri}\"");
            headerValue.Add($"algorithm={algorithm}");
            headerValue.Add($"nonce=\"{wwwAuthenticateHeader.Nonce}\"");
            headerValue.Add($"nc={NonceCount[wwwAuthenticateHeader.Nonce]:x8}");
            headerValue.Add($"cnonce=\"{cnonce}\"");
            if (!String.IsNullOrEmpty(qop))
                headerValue.Add($"qop={qop}");
            headerValue.Add($"response=\"{responseHash}\"");
            headerValue.Add($"opaque=\"{wwwAuthenticateHeader.Opaque}\"");

            return new HttpHeader("Authorization", $"Digest {String.Join(",", headerValue)}");
        }

        private static string ExtractParameterValue(string wwwAuthenticateHeader, string key, string pattern)
        {
            string value = "";

            Match parameter = Regex.Match(wwwAuthenticateHeader, $"{key}={pattern}");
            if (parameter.Success)
                value = parameter.Groups[1].Value;

            return value;
        }

        private static string GenerateCnonce()
        {
            Random random = new Random();

            uint thirtyBits = (uint)random.Next(1 << 30);
            uint twoBits = (uint)random.Next(1 << 2);
            uint cnonce = (thirtyBits << 2) | twoBits;

            return cnonce.ToString("x8");
        }
        /*
        private bool IsPrintableASCII(string str)
        {
            foreach (char c in str)
                if (c <= 31 || c >= 128)
                    return false;

            return true;
        }
        */
        private static string MD5Hash(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = MD5.Create().ComputeHash(inputBytes);
            StringBuilder hash = new StringBuilder();
            foreach (byte hashByte in hashBytes)
                hash.Append($"{hashByte:x2}");
            return hash.ToString();
        }

        private class WWWAuthenticateHeader
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
}