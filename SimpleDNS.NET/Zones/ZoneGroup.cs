using Newtonsoft.Json;

namespace SimpleDNS.Zones;

public class ZoneGroup
{
    [JsonProperty("Serial")]
    public uint Id { get; set; }

    [JsonProperty("Name")]
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}