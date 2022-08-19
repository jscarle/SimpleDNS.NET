using Newtonsoft.Json;

namespace SimpleDNS.Plugins;

public class Plugin
{
    [JsonProperty("ID")]
    public string Id { get; set; }

    [JsonProperty("DisplayName")]
    public string DisplayName { get; set; }

    [JsonProperty("Interface")]
    public string Interface { get; set; }

    [JsonProperty("DLL")]
    public string Dll { get; set; }

    [JsonProperty("TypeName")]
    public string TypeName { get; set; }

    [JsonProperty("IPListAllowRecursion")]
    public bool IpListAllowRecursion { get; set; }

    [JsonProperty("IPListDNSBLWhiteList")]
    public bool IpListDnsblWhiteList { get; set; }

    [JsonProperty("MaxThreads")]
    public uint MaxThreads { get; set; }

    [JsonProperty("MaxQueue")]
    public uint MaxQueue { get; set; }
}