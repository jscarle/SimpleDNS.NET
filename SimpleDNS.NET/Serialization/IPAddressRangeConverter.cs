using System;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Serialization
{
    public class IPAddressRangeConverter : JsonConverter<IPAddressRange>
    {
        public override void WriteJson(JsonWriter writer, IPAddressRange value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString());
        }

        public override IPAddressRange ReadJson(JsonReader reader, Type objectType, IPAddressRange existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return reader.Value == null ? null : IPAddressRange.Parse((string)reader.Value);
        }
    }
}
