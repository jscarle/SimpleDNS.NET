using System;
using Newtonsoft.Json;

namespace SimpleDNS.Zones;

public class DnsSecKey
{
    [JsonProperty("ID")]
    public string Id { get; set; }

    [JsonProperty("Type")]
    public ZskKeyType Type { get; set; }

    [JsonProperty("Created")]
    public DateTime Created { get; set; }

    [JsonProperty("Algorithm")]
    public ZskAlgorithm Algorithm { get; set; }

    [JsonProperty("KeySize")]
    public ZskKeySize KeySize { get; set; }

    [JsonProperty("KeyTag")]
    public ushort KeyTag { get; set; }

    [JsonProperty("NoSign")]
    public bool NoSign { get; set; }

    [JsonProperty("Delete")]
    public DateTime Delete { get; set; }

    [JsonProperty("Notes")]
    public string Notes { get; set; }
}