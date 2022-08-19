using System;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.IPBlocks;

public class BlockMatch
{
    [JsonProperty("Match")]
    public IpAddressRange Match { get; set; }

    [JsonProperty("Comments")]
    public string Comments { get; set; }

    [JsonProperty("Expires")]
    public DateTime? Expires { get; set; }
}