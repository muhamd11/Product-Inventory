using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DynamicPropertyNameConverter<T> : JsonConverter<IEnumerable<T>>
{
    private readonly string _propertyName;

    public DynamicPropertyNameConverter(string propertyName)
    {
        _propertyName = propertyName;
    }

    public override IEnumerable<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, IEnumerable<T> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName(_propertyName);
        JsonSerializer.Serialize(writer, value, options);
        writer.WriteEndObject();
    }
}
