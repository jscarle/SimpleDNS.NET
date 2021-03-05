using Newtonsoft.Json;
using SimpleDNS.Serialization;

namespace SimpleDNS.Common
{
    [JsonConverter(typeof(TSIGAlgorithmConverter))]
    public enum TSIGAlgorithm
    {
        HMACMD5,
        HMACSHA1,
        HMACSHA256,
        HMACSHA384,
        HMACSHA512
    }
}
