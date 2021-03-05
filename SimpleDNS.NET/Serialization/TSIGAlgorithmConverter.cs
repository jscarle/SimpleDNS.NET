using System;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Serialization
{
    public class TSIGAlgorithmConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((TSIGAlgorithm)value)
            {
                case TSIGAlgorithm.HMACMD5:
                    writer.WriteValue("HMAC-MD5");
                    break;
                case TSIGAlgorithm.HMACSHA1:
                    writer.WriteValue("HMAC-SHA1");
                    break;
                case TSIGAlgorithm.HMACSHA256:
                    writer.WriteValue("HMAC-SHA256");
                    break;
                case TSIGAlgorithm.HMACSHA384:
                    writer.WriteValue("HMAC-SHA384");
                    break;
                case TSIGAlgorithm.HMACSHA512:
                    writer.WriteValue("HMAC-SHA512");
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return (string) reader.Value switch
            {
                "HMAC-MD5" => TSIGAlgorithm.HMACMD5,
                "HMAC-SHA1" => TSIGAlgorithm.HMACSHA1,
                "HMAC-SHA256" => TSIGAlgorithm.HMACSHA256,
                "HMAC-SHA384" => TSIGAlgorithm.HMACSHA384,
                "HMAC-SHA512" => TSIGAlgorithm.HMACSHA512,
                _ => null
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
