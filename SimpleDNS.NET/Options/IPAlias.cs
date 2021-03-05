using System.Net;
using Newtonsoft.Json;

namespace SimpleDNS.Options
{
    public class IPAlias : ICommittable
    {
        [JsonIgnore]
        public bool Changed { get { return (Ext_changed | Int_changed); } }
        public void Commit()
        {
            Ext_changed = false;
            Int_changed = false;
        }

        [JsonProperty("Ext")]
        public IPAddress Ext { get { return Ext_value; } set { Ext_changed = true; Ext_value = value; } }
        private IPAddress Ext_value;
        private bool Ext_changed;

        [JsonProperty("Int")]
        public IPAddress Int { get { return Int_value; } set { Int_changed = true; Int_value = value; } }
        private IPAddress Int_value;
        private bool Int_changed;
    }
}