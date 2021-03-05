using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SimpleDNS.Options
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DNSLameAction
    {
        Refuse,
        Stealth,
        ReferRoot,
        Synth
    }
}
