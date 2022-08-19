using System;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Serialization;

public class IpAddressRangeConverter : JsonConverter<IpAddressRange>
{
    public override void WriteJson(JsonWriter writer, IpAddressRange value, JsonSerializer serializer)
    {
        writer.WriteValue(value?.ToString());
    }

    public override IpAddressRange ReadJson(JsonReader reader, Type objectType, IpAddressRange existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return reader.Value == null ? null : IpAddressRange.Parse((string)reader.Value);
    }
}