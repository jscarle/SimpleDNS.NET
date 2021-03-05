using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace SimpleDNS.Zones
{
    public class ZoneConfiguration
    {
        [JsonProperty("Type")]
        public ZoneType Type { get; set; }

        [JsonProperty("DefaultTTL")]
        public int DefaultTTL { get; set; }

        [JsonProperty("PrimaryIP")]
        public IPAddress PrimaryIP { get; set; }

        [JsonProperty("ZTKey")]
        public ZTKey ZTKey { get; set; }

        [JsonProperty("Account")]
        public string Account { get; set; }

        [JsonProperty("Group")]
        public int Group { get; set; }

        [JsonProperty("AllowZTKeys")]
        public List<ZTKey> AllowZTKeys { get; set; }

        [JsonProperty("AllowZT")]
        public Allow AllowZT { get; set; }

        [JsonProperty("NotifyNS")]
        public bool NotifyNS { get; set; }
        
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
        public bool GenZSK { get; set; }

        [JsonProperty("GenZSKDays")]
        public int GenZSKDays { get; set; }

        [JsonProperty("GenZSKAlgo")]
        public ZSKAlgorithm GenZSKAlgo { get; set; }

        [JsonProperty("GenZSKKeySize")]
        public ZSKKeySize GenZSKKeySize { get; set; }

        [JsonProperty("GenZSKRemoveDays")]
        public int GenZSKRemoveDays { get; set; }

        [JsonProperty("NSEC3")]
        public bool NSEC3 { get; set; }

        [JsonProperty("NSEC3SaltLength")]
        public int NSEC3SaltLength { get; set; }

        [JsonProperty("NSEC3Iterations")]
        public int NSEC3Iterations { get; set; }

        [JsonProperty("Comments")]
        public string Comments { get; set; }
    }
}
