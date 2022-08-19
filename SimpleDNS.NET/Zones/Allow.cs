using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Zones;

public class Allow
{
    [JsonProperty("Match")]
    public MatchType Match { get; set; }

    [JsonProperty("Items")]
    public List<IpAddressRange> Items { get; set; }
}