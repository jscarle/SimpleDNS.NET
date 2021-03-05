using System;
using Newtonsoft.Json;

namespace SimpleDNS.Zones
{
    public class DNSSecKey
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("Type")]
        public ZSKKeyType Type { get; set; }

        [JsonProperty("Created")]
        public DateTime Created { get; set; }

        [JsonProperty("Algorithm")]
        public ZSKAlgorithm Algorithm { get; set; }

        [JsonProperty("KeySize")]
        public ZSKKeySize KeySize { get; set; }

        [JsonProperty("KeyTag")]
        public ushort KeyTag { get; set; }

        [JsonProperty("NoSign")]
        public bool NoSign { get; set; }

        [JsonProperty("Delete")]
        public DateTime Delete { get; set; }

        [JsonProperty("Notes")]
        public string Notes { get; set; }
    }
}
