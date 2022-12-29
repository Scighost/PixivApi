using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Illust;


/// <summary>
/// 添加插画收藏请求
/// </summary>
public class AddBookmarkIllustRequest
{
    /// <summary>
    /// 插画id
    /// </summary>
    [JsonPropertyName("illust_id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int IllustId { get; set; }

    /// <summary>
    /// 不公开
    /// </summary>
    [JsonPropertyName("restrict")]
    [JsonConverter(typeof(BoolToNumberJsonConverter))]
    public bool IsPrivate { get; set; }

    /// <summary>
    /// 评论
    /// </summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    /// <summary>
    /// 自定义标签
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; set; }
}
