using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Zones
{
    public class ZTKey
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Algorithm")]
        public TSIGAlgorithm Algorithm { get; set; }

        [JsonProperty("Secret")]
        public string Secret { get; set; }
    }
}
