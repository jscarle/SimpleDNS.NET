using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SimpleDNS.Options;

[JsonConverter(typeof(StringEnumConverter))]
public enum DnsLameAction
{
    Refuse,
    Stealth,
    ReferRoot,
    Synth
}