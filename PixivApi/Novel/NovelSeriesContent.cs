using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Novel;


internal class NovelSeriesContentWrapper
{
    [JsonPropertyName("seriesContents")]
    public List<NovelSeriesChapter> SeriesContents { get; set; }
}


/// <summary>
/// 小说系列的章节信息（无正文）
/// </summary>
public class NovelSeriesChapter
{

    /// <summary>
    /// 小说id
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int Id { get; set; }

    /// <summary>
    /// 作者uid
    /// </summary>
    [JsonPropertyName("userId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int UserId { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 标签
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    /// <summary>
    /// 限制级别
    /// </summary>
    [JsonPropertyName("xRestrict")]
    public XRestrict XRestrict { get; set; }

    /// <summary>
    /// 原创
    /// </summary>
    [JsonPropertyName("isOriginal")]
    public bool IsOriginal { get; set; }

    /// <summary>
    /// 字符数
    /// </summary>
    [JsonPropertyName("textLength")]
    public int TextLength { get; set; }

    /// <summary>
    /// 字符数
    /// </summary>
    [JsonPropertyName("characterCount")]
    public int CharacterCount { get; set; }

    /// <summary>
    /// 文字数
    /// </summary>
    [JsonPropertyName("wordCount")]
    public int WordCount { get; set; }

    /// <summary>
    /// 阅读时间，单位秒
    /// </summary>
    [JsonPropertyName("readingTime")]
    public int ReadingTime { get; set; }

    /// <summary>
    /// 收藏数
    /// </summary>
    [JsonPropertyName("bookmarkCount")]
    public int BookmarkCount { get; set; }

    /// <summary>
    /// 封面图片
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// 上传时间戳
    /// </summary>
    [JsonPropertyName("uploadTimestamp")]
    public int UploadTimestamp { get; set; }

    /// <summary>
    /// 重新上传时间戳
    /// </summary>
    [JsonPropertyName("reuploadTimestamp")]
    public int ReuploadTimestamp { get; set; }

    /// <summary>
    /// 收藏信息，为 null 时未收藏
    /// </summary>
    [JsonPropertyName("bookmarkData")]
    public BookmarkData? BookmarkData { get; set; }

}
