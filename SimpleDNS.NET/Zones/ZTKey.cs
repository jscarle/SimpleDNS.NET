using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Zones;

public class ZtKey
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Algorithm")]
    public TsigAlgorithm Algorithm { get; set; }

    [JsonProperty("Secret")]
    public string Secret { get; set; }
}