namespace Scighost.PixivApi.Common;

/// <summary>
/// 作品的收藏属性
/// </summary>
public class BookmarkData
{
    /// <summary>
    /// 收藏id
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public long Id { get; set; }

    /// <summary>
    /// 不公开
    /// </summary>
    [JsonPropertyName("private")]
    public bool Private { get; set; }

}