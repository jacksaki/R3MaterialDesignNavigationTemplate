using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace R3MaterialDesignNavigationTemplate.Extensions;
public class BindableReactivePropertyConverter<T> : JsonConverter<BindableReactiveProperty<T>>
{
    public override BindableReactiveProperty<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            reader.Read();
            return null;
        }

        var value = JsonSerializer.Deserialize<T>(ref reader, options);
        return new BindableReactiveProperty<T>(value!);
    }

    public override void Write(Utf8JsonWriter writer, BindableReactiveProperty<T> value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value.Value, options);
    }
}
