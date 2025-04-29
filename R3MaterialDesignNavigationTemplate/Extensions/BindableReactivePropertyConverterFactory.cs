using R3;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace R3MaterialDesignNavigationTemplate.Extensions;
using System;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

public class BindableReactivePropertyConverterFactory : JsonConverterFactory
{
    private static readonly ConcurrentDictionary<Type, JsonConverter> _cache = new();

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(BindableReactiveProperty<>);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return _cache.GetOrAdd(typeToConvert, static (t) =>
        {
            var genericType = t.GetGenericArguments()[0];
            var converterType = typeof(BindableReactivePropertyConverter<>).MakeGenericType(genericType);
            return (JsonConverter)Activator.CreateInstance(converterType)!;
        });
    }
}

