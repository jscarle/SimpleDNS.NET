using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SimpleDNS.Authenticators;
using SimpleDNS.Common;
using SimpleDNS.IPBlocks;
using SimpleDNS.Options;
using SimpleDNS.Plugins;
using SimpleDNS.Serialization;
using SimpleDNS.Statistics;
using SimpleDNS.Zones;

namespace SimpleDNS;

public class SimpleDnsManager
{
    private readonly RestClient _client;
    private readonly JsonSerializerSettings _jsonSerializerSettings;

    public SimpleDnsManager(string baseUrl, AuthenticationMode authenticationMode = AuthenticationMode.None, string username = "", string password = "", bool ignoreInvalidCertificate = false)
    {
        _jsonSerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
            Converters = new JsonConverter[] { new IpAddressConverter(), new IpAddressRangeConverter() }
        };

        _client = new RestClient(baseUrl);
        _client.Authenticator = authenticationMode switch
        {
            AuthenticationMode.Basic => new HttpBasicAuthenticator(username, password),
            AuthenticationMode.Digest => new HttpDigestAuthenticator(username, password),
            AuthenticationMode.Integrated => new NtlmAuthenticator(username, password),
            _ => _client.Authenticator
        };
        if (ignoreInvalidCertificate)
            _client.RemoteCertificateValidationCallback = (_, _, _, _) => true;
    }

    #region /zones

    public List<Zone> GetZones()
    {
        var request = new RestRequest("/zones", Method.GET, DataFormat.Json);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<List<Zone>>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /zones/{zonename}

    public ZoneConfiguration GetZone(string zoneName)
    {
        var request = new RestRequest("/zones/{zonename}", Method.GET, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<ZoneConfiguration>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /zones/{zonename}/records

    public List<ZoneRecord> GetZoneRecords(string zoneName)
    {
        var request = new RestRequest("/zones/{zonename}/records", Method.GET, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<List<ZoneRecord>>(response.Content, _jsonSerializerSettings);
        return result;
    }

    public void PatchZoneRecords(string zoneName, List<ZoneRecord> input)
    {
        var json = JsonConvert.SerializeObject(input, _jsonSerializerSettings);

        var request = new RestRequest("/zones/{zonename}/records", Method.PATCH, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        ValidateResponse(_client.Execute(request));
    }

    public void PutZoneRecords(string zoneName, List<ZoneRecord> input)
    {
        var json = JsonConvert.SerializeObject(input, _jsonSerializerSettings);

        var request = new RestRequest("/zones/{zonename}/records", Method.PUT, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        ValidateResponse(_client.Execute(request));
    }

    #endregion

    #region /zones/{zonename}/dnsseckeys

    public List<DnsSecKey> GetZoneDnsSecKeys(string zoneName)
    {
        var request = new RestRequest("/zones/{zonename}/dnsseckeys", Method.GET, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<List<DnsSecKey>>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /zones/{zonename}/dnsseckeys/{keyid}

    public DnsSecKey GetZoneDnsSecKey(string zoneName, string keyid)
    {
        var request = new RestRequest("/zones/{zonename}/dnsseckeys/{keyid}", Method.GET, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        request.AddParameter("keyid", keyid, ParameterType.UrlSegment);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<DnsSecKey>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /zones/{zonename}/dnssecds

    public List<DnsSecDs> GetZoneDnsSecDs(string zoneName)
    {
        var request = new RestRequest("/zones/{zonename}/dnssecds", Method.GET, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<List<DnsSecDs>>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /zones/{zonename}/masterfile

    public string GetZoneMasterFile(string zoneName)
    {
        var request = new RestRequest("/zones/{zonename}/masterfile", Method.GET, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        var response = ValidateResponse(_client.Execute(request));
        return response.Content;
    }

    #endregion

    #region /zones/{zonename}/versions

    public List<ZoneVersion> GetZoneVersions(string zoneName)
    {
        var request = new RestRequest("/zones/{zonename}/versions", Method.GET, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<List<ZoneVersion>>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /zones/{zonename}/state

    public ZoneState GetZoneState(string zoneName)
    {
        var request = new RestRequest("/zones/{zonename}/state", Method.GET, DataFormat.Json);
        request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<ZoneState>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /zonesgroups

    public List<ZoneGroup> GetZoneGroups()
    {
        var request = new RestRequest("/zonegroups", Method.GET, DataFormat.Json);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<List<ZoneGroup>>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /options

    public OptionsInfo GetOptions()
    {
        var request = new RestRequest("/options", Method.GET, DataFormat.Json);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<OptionsInfo>(response.Content, _jsonSerializerSettings);
        result?.Commit();
        return result;
    }

    public void PatchOptions(OptionsInfo input)
    {
        var json = JsonConvert.SerializeObject(input, _jsonSerializerSettings);

        var request = new RestRequest("/options", Method.PATCH, DataFormat.Json);
        request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        ValidateResponse(_client.Execute(request));
    }

    public void PutOptions(OptionsInfo input)
    {
        var json = JsonConvert.SerializeObject(input, _jsonSerializerSettings);

        var request = new RestRequest("/options", Method.PUT, DataFormat.Json);
        request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
        ValidateResponse(_client.Execute(request));
    }

    #endregion

    #region /statistics

    public StatisticsInfo GetStatistics()
    {
        var request = new RestRequest("/statistics", Method.GET, DataFormat.Json);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<StatisticsInfo>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /ipblock

    public IpBlocksInfo GetIpBlocks()
    {
        var request = new RestRequest("/ipblock", Method.GET, DataFormat.Json);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<IpBlocksInfo>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    #region /plugins

    public PluginsInfo GetPlugins()
    {
        var request = new RestRequest("/plugins", Method.GET, DataFormat.Json);
        var response = ValidateResponse(_client.Execute(request));
        var result = JsonConvert.DeserializeObject<PluginsInfo>(response.Content, _jsonSerializerSettings);
        return result;
    }

    #endregion

    private static RestResponse ValidateResponse(IRestResponse response)
    {
        if (response.ResponseStatus == ResponseStatus.Error)
            throw new WebException(response.ErrorMessage, response.ErrorException);

        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NoContent)
            throw new WebException($"{response.StatusCode} {response.StatusDescription}", WebExceptionStatus.ProtocolError);

        return (RestResponse)response;
    }
}

public static class Main
{
    public static void Entry()
    {
string adminUrl = "https://localhost/v2";
string adminUsername = "admin";
string adminPassword = "password";
SimpleDnsManager simpleDns = new SimpleDnsManager(adminUrl, AuthenticationMode.Digest, adminUsername, adminPassword, true);

var options = simpleDns.GetOptions();
options.DnsCacheReload = false;
simpleDns.PatchOptions(options);
    }
}