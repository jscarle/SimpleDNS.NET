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

namespace SimpleDNS
{
    public class SimpleDNSManager
    {
        private readonly RestClient client;
        private readonly JsonSerializerSettings jsonSerializerSettings;

        public SimpleDNSManager(string baseUrl, AuthenticationMode authenticationMode = AuthenticationMode.None, string username = "", string password = "", bool ignoreInvalidCertificate = false)
        {
            jsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new JsonConverter[] { new IPAddressConverter(), new IPAddressRangeConverter() }
            };

            client = new RestClient(baseUrl);
            switch (authenticationMode)
            {
                case AuthenticationMode.Basic:
                    client.Authenticator = new HttpBasicAuthenticator(username, password);
                    break;
                case AuthenticationMode.Digest:
                    client.Authenticator = new HttpDigestAuthenticator(username, password);
                    break;
                case AuthenticationMode.Integrated:
                    client.Authenticator = new NtlmAuthenticator(username, password);
                    break;
            }
            if (ignoreInvalidCertificate)
                client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

        #region /zones

        public List<Zone> GetZones()
        {
            RestRequest request = new RestRequest("/zones", Method.GET, DataFormat.Json);
            RestResponse response = ValidateResponse(client.Execute(request));
            List<Zone> result = JsonConvert.DeserializeObject<List<Zone>>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /zones/{zonename}

        public ZoneConfiguration GetZone(string zoneName)
        {
            RestRequest request = new RestRequest("/zones/{zonename}", Method.GET, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            RestResponse response = ValidateResponse(client.Execute(request));
            ZoneConfiguration result = JsonConvert.DeserializeObject<ZoneConfiguration>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /zones/{zonename}/records

        public List<ZoneRecord> GetZoneRecords(string zoneName)
        {
            RestRequest request = new RestRequest("/zones/{zonename}/records", Method.GET, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            RestResponse response = ValidateResponse(client.Execute(request));
            List<ZoneRecord> result = JsonConvert.DeserializeObject<List<ZoneRecord>>(response.Content, jsonSerializerSettings);
            return result;
        }

        public void PatchZoneRecords(string zoneName, List<ZoneRecord> input)
        {
            string json = JsonConvert.SerializeObject(input, jsonSerializerSettings);

            RestRequest request = new RestRequest("/zones/{zonename}/records", Method.PATCH, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            ValidateResponse(client.Execute(request));
        }

        public void PutZoneRecords(string zoneName, List<ZoneRecord> input)
        {
            string json = JsonConvert.SerializeObject(input, jsonSerializerSettings);

            RestRequest request = new RestRequest("/zones/{zonename}/records", Method.PUT, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            ValidateResponse(client.Execute(request));
        }

        #endregion

        #region /zones/{zonename}/dnsseckeys

        public List<DNSSecKey> GetZoneDNSSecKeys(string zoneName)
        {
            RestRequest request = new RestRequest("/zones/{zonename}/dnsseckeys", Method.GET, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            RestResponse response = ValidateResponse(client.Execute(request));
            List<DNSSecKey> result = JsonConvert.DeserializeObject<List<DNSSecKey>>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /zones/{zonename}/dnsseckeys/{keyid}

        public DNSSecKey GetZoneDNSSecKey(string zoneName, string keyid)
        {
            RestRequest request = new RestRequest("/zones/{zonename}/dnsseckeys/{keyid}", Method.GET, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            request.AddParameter("keyid", keyid, ParameterType.UrlSegment);
            RestResponse response = ValidateResponse(client.Execute(request));
            DNSSecKey result = JsonConvert.DeserializeObject<DNSSecKey>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /zones/{zonename}/dnssecds

        public List<DNSSecDS> GetZoneDNSSecDS(string zoneName)
        {
            RestRequest request = new RestRequest("/zones/{zonename}/dnssecds", Method.GET, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            RestResponse response = ValidateResponse(client.Execute(request));
            List<DNSSecDS> result = JsonConvert.DeserializeObject<List<DNSSecDS>>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /zones/{zonename}/masterfile

        public string GetZoneMasterFile(string zoneName)
        {
            RestRequest request = new RestRequest("/zones/{zonename}/masterfile", Method.GET, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            RestResponse response = ValidateResponse(client.Execute(request));
            return response.Content;
        }

        #endregion

        #region /zones/{zonename}/versions

        public List<ZoneVersion> GetZoneVersions(string zoneName)
        {
            RestRequest request = new RestRequest("/zones/{zonename}/versions", Method.GET, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            RestResponse response = ValidateResponse(client.Execute(request));
            List<ZoneVersion> result = JsonConvert.DeserializeObject<List<ZoneVersion>>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /zones/{zonename}/state

        public ZoneState GetZoneState(string zoneName)
        {
            RestRequest request = new RestRequest("/zones/{zonename}/state", Method.GET, DataFormat.Json);
            request.AddParameter("zonename", zoneName, ParameterType.UrlSegment);
            RestResponse response = ValidateResponse(client.Execute(request));
            ZoneState result = JsonConvert.DeserializeObject<ZoneState>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /zonesgroups

        public List<ZoneGroup> GetZoneGroups()
        {
            RestRequest request = new RestRequest("/zonegroups", Method.GET, DataFormat.Json);
            RestResponse response = ValidateResponse(client.Execute(request));
            List<ZoneGroup> result = JsonConvert.DeserializeObject<List<ZoneGroup>>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /options

        public OptionsInfo GetOptions()
        {
            RestRequest request = new RestRequest("/options", Method.GET, DataFormat.Json);
            RestResponse response = ValidateResponse(client.Execute(request));
            OptionsInfo result = JsonConvert.DeserializeObject<OptionsInfo>(response.Content, jsonSerializerSettings);
            result?.Commit();
            return result;
        }

        public void PatchOptions(OptionsInfo input)
        {
            string json = JsonConvert.SerializeObject(input, jsonSerializerSettings);

            RestRequest request = new RestRequest("/options", Method.PATCH, DataFormat.Json);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            ValidateResponse(client.Execute(request));
        }

        public void PutOptions(OptionsInfo input)
        {
            string json = JsonConvert.SerializeObject(input, jsonSerializerSettings);

            RestRequest request = new RestRequest("/options", Method.PUT, DataFormat.Json);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            ValidateResponse(client.Execute(request));
        }

        #endregion

        #region /statistics

        public StatisticsInfo GetStatistics()
        {
            RestRequest request = new RestRequest("/statistics", Method.GET, DataFormat.Json);
            RestResponse response = ValidateResponse(client.Execute(request));
            StatisticsInfo result = JsonConvert.DeserializeObject<StatisticsInfo>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /ipblock

        public IPBlocksInfo GetIPBlocks()
        {
            RestRequest request = new RestRequest("/ipblock", Method.GET, DataFormat.Json);
            RestResponse response = ValidateResponse(client.Execute(request));
            IPBlocksInfo result = JsonConvert.DeserializeObject<IPBlocksInfo>(response.Content, jsonSerializerSettings);
            return result;
        }

        #endregion

        #region /plugins

        public PluginsInfo GetPlugins()
        {
            RestRequest request = new RestRequest("/plugins", Method.GET, DataFormat.Json);
            RestResponse response = ValidateResponse(client.Execute(request));
            PluginsInfo result = JsonConvert.DeserializeObject<PluginsInfo>(response.Content, jsonSerializerSettings);
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
}
