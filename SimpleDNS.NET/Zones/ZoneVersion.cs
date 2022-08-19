using System;
using Newtonsoft.Json;

namespace SimpleDNS.Zones;

public class ZoneVersion
{
    [JsonProperty("Serial")]
    public uint Serial { get; set; }

    [JsonProperty("TimeUTC")]
    public DateTime TimeUtc { get; set; }

    [JsonProperty("Current")]
    public bool Current { get; set; }

    [JsonProperty("Description")]
    public string Description { get; set; }
}