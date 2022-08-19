using Newtonsoft.Json;

namespace SimpleDNS.IPBlocks;

public class AutoBlock
{
    [JsonProperty("Enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("MaxReqs")]
    public ushort MaxReqs { get; set; }

    [JsonProperty("WithinSecs")]
    public ushort WithinSecs { get; set; }

    [JsonProperty("Mode")]
    public BlockMode Mode { get; set; }

    [JsonProperty("FixedTime")]
    public uint FixedTime { get; set; }
}