using System.Net;
using Newtonsoft.Json;

namespace SimpleDNS.Options
{
    public class Master : ICommittable
    {
        public Master()
        {
            TSigKey_value = new Key();
        }

        [JsonIgnore]
        public bool Changed { get { return (IP_changed | TSigKey_changed | TSigKey_value.Changed); } }
        public void Commit()
        {
            IP_changed = false;
            TSigKey_changed = false;

            TSigKey_value.Commit();
        }

        [JsonProperty("IP")]
        public IPAddress IP { get { return IP_value; } set { IP_changed = true; IP_value = value; } }
        private IPAddress IP_value;
        private bool IP_changed;

        [JsonProperty("TSigKey")]
        public Key TSigKey { get { return TSigKey_value; } set { TSigKey_changed = true; TSigKey_value = value; } }
        private Key TSigKey_value;
        private bool TSigKey_changed;
    }
}