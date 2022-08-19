using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace SimpleDNS.Zones;

public class ZoneConfiguration
{
    [JsonProperty("Type")]
    public ZoneType Type { get; set; }

    [JsonProperty("DefaultTTL")]
    public int DefaultTtl { get; set; }

    [JsonProperty("PrimaryIP")]
    public IPAddress PrimaryIp { get; set; }

    [JsonProperty("ZTKey")]
    public ZtKey ZtKey { get; set; }

    [JsonProperty("Account")]
    public string Account { get; set; }

    [JsonProperty("Group")]
    public int Group { get; set; }

    [JsonProperty("AllowZTKeys")]
    public List<ZtKey> AllowZtKeys { get; set; }

    [JsonProperty("AllowZT")]
    public Allow AllowZt { get; set; }

    [JsonProperty("NotifyNS")]
    public bool NotifyNs { get; set; }
        
    [JsonProperty("AlsoNotify")]
    public List<IPAddress> AlsoNotify { get; set; }

    [JsonProperty("AllowUpdate")]
    public Allow AllowUpdate { get; set; }

    [JsonProperty("AutoSign")]
    public bool AutoSign { get; set; }

    [JsonProperty("AutoSignRepeatDays")]
    public int AutoSignRepeatDays { get; set; }

    [JsonProperty("AutoSignValidDays")]
    public int AutoSignValidDays { get; set; }

    [JsonProperty("GenZSK")]
    public bool GenZsk { get; set; }

    [JsonProperty("GenZSKDays")]
    public int GenZskDays { get; set; }

    [JsonProperty("GenZSKAlgo")]
    public ZskAlgorithm GenZskAlgo { get; set; }

    [JsonProperty("GenZSKKeySize")]
    public ZskKeySize GenZskKeySize { get; set; }

    [JsonProperty("GenZSKRemoveDays")]
    public int GenZskRemoveDays { get; set; }

    [JsonProperty("NSEC3")]
    public bool Nsec3 { get; set; }

    [JsonProperty("NSEC3SaltLength")]
    public int Nsec3SaltLength { get; set; }

    [JsonProperty("NSEC3Iterations")]
    public int Nsec3Iterations { get; set; }

    [JsonProperty("Comments")]
    public string Comments { get; set; }
}