using Newtonsoft.Json;

namespace SimpleDNS.Zones
{
    public class ZoneRecord
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Type")]
        public RecordType Type { get; set; }

        [JsonProperty("TTL")]
        public uint TTL { get; set; }

        [JsonProperty("Data")]
        public string Data { get; set; }

        [JsonProperty("Comment")]
        public string Comment { get; set; }

        [JsonProperty("Remove")]
        public bool? Remove { get; set; }
    }
}
