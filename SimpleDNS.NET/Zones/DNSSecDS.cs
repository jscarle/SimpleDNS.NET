using Newtonsoft.Json;

namespace SimpleDNS.Zones
{
    public class DNSSecDS
    {
        [JsonProperty("KeyTag")]
        public ushort KeyTag { get; set; }

        //[JsonProperty("Algorithm")]
        [JsonIgnore]
        public DSAlgorithm Algorithm { get { return (DSAlgorithm)AlgorithmNumeric; } }

        [JsonProperty("AlgorithmNumeric")]
        public byte AlgorithmNumeric { get; set; }

        //[JsonProperty("DigestType")]
        [JsonIgnore]
        public DSDigestType DigestType { get { return (DSDigestType)DigestTypeNumeric; } }

        [JsonProperty("DigestTypeNumeric")]
        public byte DigestTypeNumeric { get; set; }

        [JsonProperty("Digest")]
        public string Digest { get; set; }

        [JsonProperty("MasterFileData")]
        public string MasterFileData { get; set; }
    }
}
