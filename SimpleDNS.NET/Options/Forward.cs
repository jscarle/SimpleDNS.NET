using Newtonsoft.Json;

namespace SimpleDNS.Options
{
    public class Forward : ICommittable
    {
        public Forward()
        {
            IP_value = new IPAddressList();
        }

        [JsonIgnore]
        public bool Changed { get { return (Domain_changed | Extended_changed | Shadow_changed | ShadowAA_changed | IP_changed | IP_value.Changed); } }
        public void Commit()
        {
            Domain_changed = false;
            Extended_changed = false;
            Shadow_changed = false;
            ShadowAA_changed = false;
            IP_changed = false;

            IP_value.Commit();
        }

        [JsonProperty("Domain")]
        public string Domain { get { return Domain_value; } set { Domain_changed = true; Domain_value = value; } }
        private string Domain_value;
        private bool Domain_changed;

        [JsonProperty("Extended")]
        public bool Extended { get { return Extended_value; } set { Extended_changed = true; Extended_value = value; } }
        private bool Extended_value;
        private bool Extended_changed;

        [JsonProperty("Shadow")]
        public bool Shadow { get { return Shadow_value; } set { Shadow_changed = true; Shadow_value = value; } }
        private bool Shadow_value;
        private bool Shadow_changed;

        [JsonProperty("ShadowAA")]
        public bool ShadowAA { get { return ShadowAA_value; } set { ShadowAA_changed = true; ShadowAA_value = value; } }
        private bool ShadowAA_value;
        private bool ShadowAA_changed;

        [JsonProperty("IP")]
        public IPAddressList IP { get { return IP_value; } set { IP_changed = true; IP_value = value; } }
        private IPAddressList IP_value;
        private bool IP_changed;
    }
}