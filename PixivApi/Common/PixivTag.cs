using System.Text.Json;

namespace Scighost.PixivApi.Common;


/// <summary>
/// 作品的标签原始信息，对应的json结构有些复杂，为了减少实体类的数量，此类在不同情况下的有效属性不同。
/// <para />
/// 作者以外的其他用户也可以给作品添加标签，编辑标签后会发送通知给作者，作者可以接受并锁定标签使之不可编辑，也可以锁定作品的全部标签。
/// </summary>
internal class PixivTagInternal
{

    /// <summary>
    /// 作者的uid
    /// </summary>
    [JsonPropertyName("authorId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int AuthorId { get; set; }

    /// <summary>
    /// 标签是否被作者锁定
    /// </summary>
    [JsonPropertyName("isLocked")]
    public bool IsLocked { get; set; }

    /// <summary>
    /// 标签内容
    /// </summary>
    [JsonPropertyName("tags")]
    public List<PixivTagInternal> Tags { get; set; }

    /// <summary>
    /// 标签是否可更改
    /// </summary>
    [JsonPropertyName("writable")]
    public bool Writable { get; set; }

    /// <summary>
    /// 标签名
    /// </summary>
    [JsonPropertyName("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    [JsonPropertyName("locked")]
    public bool Locked { get; set; }

    /// <summary>
    /// 可删除
    /// </summary>
    [JsonPropertyName("deletable")]
    public bool Deletable { get; set; }

    /// <summary>
    /// 添加标签的用户uid
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    /// <summary>
    /// 添加标签的用户名
    /// </summary>
    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    /// <summary>
    /// 标签翻译
    /// </summary>
    [JsonPropertyName("translation")]
    public TagTranslationInternal Translation { get; set; }

}


/// <summary>
/// 标签翻译
/// </summary>
internal class TagTranslationInternal
{
    /// <summary>
    /// 标签翻译
    /// </summary>
    [JsonPropertyName("en")]
    public string Translation { get; set; }
}


/// <summary>
/// 作品标签
/// </summary>
public class PixivTag
{

    /// <summary>
    /// 标签名
    /// </summary>
    [JsonPropertyName("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// 标签翻译，小说无翻译
    /// </summary>
    [JsonPropertyName("translation")]
    public string? Translation { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    [JsonPropertyName("locked")]
    public bool Locked { get; set; }

    /// <summary>
    /// 标签是否可更改
    /// </summary>
    [JsonPropertyName("writable")]
    public bool Writable { get; set; }

    /// <summary>
    /// 可删除
    /// </summary>
    [JsonPropertyName("deletable")]
    public bool Deletable { get; set; }

    /// <summary>
    /// 添加标签的用户uid
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    /// <summary>
    /// 添加标签的用户名
    /// </summary>
    [JsonPropertyName("userName")]
    public string UserName { get; set; }

}



internal class PixivTagJsonConverter : JsonConverter<List<PixivTag>>
{
    public override List<PixivTag>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            return JsonSerializer.Deserialize<List<PixivTag>>(ref reader, options);
        }
        else
        {
            var tag = JsonSerializer.Deserialize<PixivTagInternal>(ref reader, options);
            return tag?.Tags.Select(t => new PixivTag
            {
                Deletable = t.Deletable,
                Locked = t.Locked,
                Tag = t.Tag,
                Translation = t.Translation?.Translation,
                UserId = t.UserId,
                UserName = t.UserName,
                Writable = t.Writable
            }).ToList();
        }
    }

    public override void Write(Utf8JsonWriter writer, List<PixivTag> value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(value, options));
    }
}