using Newtonsoft.Json;

namespace SimpleDNS.Zones;

public class ZoneState
{
    [JsonProperty("Serial")]
    public uint Serial { get; set; }
}