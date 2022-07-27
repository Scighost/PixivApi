using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Novel;


/// <summary>
/// 添加小说收藏的请求
/// </summary>
public class AddBookmarkNovelRequest
{
    /// <summary>
    /// 小说id
    /// </summary>
    [JsonPropertyName("novel_id")]
    [JsonNumberHandling(JsonNumberHandling.WriteAsString)]
    public int NovelId { get; set; }

    /// <summary>
    /// 非公开
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