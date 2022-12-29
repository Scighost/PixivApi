using System.Text.Json;

namespace Scighost.PixivApi.Common;


internal class DictionaryKeyToListJsonConverter<T> : JsonConverter<List<T>> where T : notnull
{
    public override List<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            return JsonSerializer.Deserialize<List<T>>(ref reader, options);
        }
        else
        {
            var dic = JsonSerializer.Deserialize<Dictionary<T, object>>(ref reader, options);
            return dic?.Keys.ToList();
        }
    }

    public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value, options));
    }
}


internal class DictionaryValueToListJsonConverter<TKey, TValue> : JsonConverter<List<TValue>> where TKey : notnull
{
    public override List<TValue>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            return JsonSerializer.Deserialize<List<TValue>>(ref reader, options);
        }
        else
        {
            var dic = JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(ref reader, options);
            return dic?.Values.ToList();
        }
    }

    public override void Write(Utf8JsonWriter writer, List<TValue> value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value, options));
    }
}


internal class BoolToNumberJsonConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var num = reader.GetInt32();
        return num != 0;
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value ? 1 : 0);
    }
}