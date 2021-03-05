using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options
{
    public class IPAddressMatch : ICommittable
    {
        public IPAddressMatch()
        {
            Items_value = new IPAddressRangeList();
        }

        [JsonIgnore]
        public bool Changed { get { return (Match_changed | Items_changed | Items_value.Changed); } }
        public void Commit()
        {
            Match_changed = false;
            Items_changed = false;

            Items_value.Commit();
        }

        [JsonProperty("Match")]
        public MatchType Match { get { return Match_value; } set { Match_changed = true; Match_value = value; } }
        private MatchType Match_value;
        private bool Match_changed;

        [JsonProperty("Items")]
        public IPAddressRangeList Items { get { return Items_value; } set { Items_changed = true; Items_value = value; } }
        private IPAddressRangeList Items_value;
        private bool Items_changed;
    }
}