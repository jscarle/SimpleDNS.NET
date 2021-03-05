using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SimpleDNS.Common
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MatchType
    {
        None,
        Some,
        Any
    }
}
