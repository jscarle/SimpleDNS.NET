using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleDNS.IPBlocks;

public class IpBlocksInfo
{
    [JsonProperty("AutoBlock")]
    public AutoBlock AutoBlock { get; set; }

    [JsonProperty("Blocked")]
    public List<BlockMatch> Blocked { get; set; }

    [JsonProperty("Trusted")]
    public List<BlockMatch> Trusted { get; set; }
}