/*
using System;
using Newtonsoft.Json;
using SimpleDNS.Zones;

namespace SimpleDNS.Serialization
{
    public class ZSKAlgorithmConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((ZSKAlgorithm)value)
            {
                case ZSKAlgorithm.RSASHA256:
                    writer.WriteValue("RSA/SHA-256");
                    break;
                case ZSKAlgorithm.RSASHA512:
                    writer.WriteValue("RSA/SHA-512");
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch ((string)reader.Value)
            {
                case "RSA/SHA-256":
                    return ZSKAlgorithm.RSASHA256;
                case "RSA/SHA-512":
                    return ZSKAlgorithm.RSASHA512;
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
*/
