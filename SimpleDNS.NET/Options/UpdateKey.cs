using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options
{
    public class UpdateKey : ICommittable
    {
        public UpdateKey()
        {
            Domains_value = new StringList();
        }

        [JsonIgnore]
        public bool Changed { get { return (KeyName_changed | Algorithm_changed | Secret_changed | Update_changed | Domains_changed | Domains_value.Changed); } }
        public void Commit()
        {
            KeyName_changed = false;
            Algorithm_changed = false;
            Secret_changed = false;
            Update_changed = false;
            Domains_changed = false;

            Domains_value.Commit();
        }

        [JsonProperty("KeyName")]
        public string KeyName { get { return KeyName_value; } set { KeyName_changed = true; KeyName_value = value; } }
        private string KeyName_value;
        private bool KeyName_changed;

        [JsonProperty("Algorithm")]
        public TSIGAlgorithm Algorithm { get { return Algorithm_value; } set { Algorithm_changed = true; Algorithm_value = value; } }
        private TSIGAlgorithm Algorithm_value;
        private bool Algorithm_changed;

        [JsonProperty("Secret")]
        public string Secret { get { return Secret_value; } set { Secret_changed = true; Secret_value = value; } }
        private string Secret_value;
        private bool Secret_changed;

        [JsonProperty("Update")]
        public string Update { get { return Update_value; } set { Update_changed = true; Update_value = value; } }
        private string Update_value;
        private bool Update_changed;

        [JsonProperty("Domains")]
        public StringList Domains { get { return Domains_value; } set { Domains_changed = true; Domains_value = value; } }
        private StringList Domains_value;
        private bool Domains_changed;
    }
}