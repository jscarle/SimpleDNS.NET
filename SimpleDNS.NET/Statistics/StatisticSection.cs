using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleDNS.Statistics;

public class StatisticSection
{
    [JsonProperty("ID")]
    public string Id { get; set; }

    [JsonProperty("Text")]
    public string Text { get; set; }

    [JsonProperty("Items")]
    public List<StatisticItem> Items { get; set; }
}