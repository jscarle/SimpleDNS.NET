using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SimpleDNS.Zones
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ZoneType
    {
        Primary,
        Secondary
    }
}
