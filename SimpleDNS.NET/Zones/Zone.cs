using Newtonsoft.Json;

namespace SimpleDNS.Zones
{
    public class Zone
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("IDN")]
        public string IDN { get; set; }

        [JsonProperty("Type")]
        public ZoneType Type { get; set; }

        [JsonProperty("Suspended")]
        public bool Suspended { get; set; }
    }
}
