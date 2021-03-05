using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleDNS.Plugins
{
    public class PluginsInfo
    {
        [JsonProperty("First")]
        public bool First { get; set; }

        [JsonProperty("Instances")]
        public List<Plugin> Instances { get; set; }
    }
}
