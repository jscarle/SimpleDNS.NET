using Newtonsoft.Json;

namespace SimpleDNS.Statistics
{
    public class StatisticItem
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Value")]
        public uint Value { get; set; }

        [JsonProperty("ValueText")]
        public string ValueText { get; set; }
    }
}
