using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Novel;

/// <summary>
/// 小说简单信息（无正文）
/// </summary>
public class NovelProfile
{
    /// <summary>
    /// 小说id
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int Id { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 限制级别
    /// </summary>
    [JsonPropertyName("xRestrict")]
    public XRestrict XRestrict { get; set; }

    /// <summary>
    /// 封面图片
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// 标签
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    /// <summary>
    /// 作者uid
    /// </summary>
    [JsonPropertyName("userId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int UserId { get; set; }

    /// <summary>
    /// 作者昵称
    /// </summary>
    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    /// <summary>
    /// 文字数
    /// </summary>
    [JsonPropertyName("textCount")]
    public int TextCount { get; set; }

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
    /// 介绍，html格式
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonPropertyName("createDate")]
    public DateTimeOffset CreateDate { get; set; }

    /// <summary>
    /// 上传时间
    /// </summary>
    [JsonPropertyName("updateDate")]
    public DateTimeOffset UpdateDate { get; set; }

    /// <summary>
    /// 系列id
    /// </summary>
    [JsonPropertyName("seriesId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int SeriesId { get; set; }

    /// <summary>
    /// 系列标题
    /// </summary>
    [JsonPropertyName("seriesTitle")]
    public string SeriesTitle { get; set; }

    /// <summary>
    /// 作者头像图片
    /// </summary>
    [JsonPropertyName("profileImageUrl")]
    public string? UserProfileImageUrl { get; set; }

}

