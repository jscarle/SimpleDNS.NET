using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleDNS.Statistics;

public class StatisticsInfo
{
    [JsonProperty("Sections")]
    public List<StatisticSection> Sections { get; set; }

    [JsonProperty("ReqPerSec")]
    public List<uint> ReqPerSec { get; set; }
}