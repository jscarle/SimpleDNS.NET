using Newtonsoft.Json;
using SimpleDNS.Serialization;

namespace SimpleDNS.Common;

[JsonConverter(typeof(TsigAlgorithmConverter))]
public enum TsigAlgorithm
{
    Hmacmd5,
    Hmacsha1,
    Hmacsha256,
    Hmacsha384,
    Hmacsha512
}