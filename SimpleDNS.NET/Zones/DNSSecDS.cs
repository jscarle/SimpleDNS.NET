using Newtonsoft.Json;

namespace SimpleDNS.Zones;

public class DnsSecDs
{
    [JsonProperty("KeyTag")]
    public ushort KeyTag { get; set; }

    //[JsonProperty("Algorithm")]
    [JsonIgnore]
    public DsAlgorithm Algorithm => (DsAlgorithm)AlgorithmNumeric;

    [JsonProperty("AlgorithmNumeric")]
    public byte AlgorithmNumeric { get; set; }

    //[JsonProperty("DigestType")]
    [JsonIgnore]
    public DsDigestType DigestType => (DsDigestType)DigestTypeNumeric;

    [JsonProperty("DigestTypeNumeric")]
    public byte DigestTypeNumeric { get; set; }

    [JsonProperty("Digest")]
    public string Digest { get; set; }

    [JsonProperty("MasterFileData")]
    public string MasterFileData { get; set; }
}