using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SimpleDNS.IPBlocks
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BlockMode
    {
        RateLimit,
        FixedTime,
        Forever
    }
}
