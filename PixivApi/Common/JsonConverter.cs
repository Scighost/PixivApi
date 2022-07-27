using System.Text.Json;

namespace Scighost.PixivApi.Common;

internal class DictionaryJsonConverter<T> : JsonConverter<Dictionary<int, T>>
{
    public override Dictionary<int, T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            reader.Read();
            return new Dictionary<int, T>();
        }
        else
        {
            return JsonSerializer.Deserialize<Dictionary<int, T>>(ref reader, options);
        }

    }

    public override void Write(Utf8JsonWriter writer, Dictionary<int, T> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
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