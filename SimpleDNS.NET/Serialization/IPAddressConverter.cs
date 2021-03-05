using System;
using System.Net;
using Newtonsoft.Json;

namespace SimpleDNS.Serialization
{
    public class IPAddressConverter : JsonConverter<IPAddress>
    {
        public override void WriteJson(JsonWriter writer, IPAddress value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString());
        }

        public override IPAddress ReadJson(JsonReader reader, Type objectType, IPAddress existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return reader.Value == null ? null : IPAddress.Parse((string)reader.Value);
        }
    }
}
