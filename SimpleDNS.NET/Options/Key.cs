using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options
{
    public class Key : ICommittable
    {
        [JsonIgnore]
        public bool Changed { get { return (Name_changed | Algorithm_changed | Secret_changed); } }
        public void Commit()
        {
            Name_changed = false;
            Algorithm_changed = false;
            Secret_changed = false;
        }

        [JsonProperty("Name")]
        public string Name { get { return Name_value; } set { Name_changed = true; Name_value = value; } }
        private string Name_value;
        private bool Name_changed;

        [JsonProperty("Algorithm")]
        public TSIGAlgorithm Algorithm { get { return Algorithm_value; } set { Algorithm_changed = true; Algorithm_value = value; } }
        private TSIGAlgorithm Algorithm_value;
        private bool Algorithm_changed;

        [JsonProperty("Secret")]
        public string Secret { get { return Secret_value; } set { Secret_changed = true; Secret_value = value; } }
        private string Secret_value;
        private bool Secret_changed;
    }
}