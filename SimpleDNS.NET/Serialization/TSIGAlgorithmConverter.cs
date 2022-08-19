using System;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Serialization;

public class TsigAlgorithmConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        switch ((TsigAlgorithm)value)
        {
            case TsigAlgorithm.Hmacmd5:
                writer.WriteValue("HMAC-MD5");
                break;
            case TsigAlgorithm.Hmacsha1:
                writer.WriteValue("HMAC-SHA1");
                break;
            case TsigAlgorithm.Hmacsha256:
                writer.WriteValue("HMAC-SHA256");
                break;
            case TsigAlgorithm.Hmacsha384:
                writer.WriteValue("HMAC-SHA384");
                break;
            case TsigAlgorithm.Hmacsha512:
                writer.WriteValue("HMAC-SHA512");
                break;
        }
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return (string) reader.Value switch
        {
            "HMAC-MD5" => TsigAlgorithm.Hmacmd5,
            "HMAC-SHA1" => TsigAlgorithm.Hmacsha1,
            "HMAC-SHA256" => TsigAlgorithm.Hmacsha256,
            "HMAC-SHA384" => TsigAlgorithm.Hmacsha384,
            "HMAC-SHA512" => TsigAlgorithm.Hmacsha512,
            _ => null
        };
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(string);
    }
}