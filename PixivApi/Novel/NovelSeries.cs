using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Novel;

/// <summary>
/// 小说系列（无章节信息）
/// </summary>
public class NovelSeries
{
    /// <summary>
    /// 系列id
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
    /// 作者昵称
    /// </summary>
    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    /// <summary>
    /// 作者头像图片
    /// </summary>
    [JsonPropertyName("profileImageUrl")]
    public string UserProfileImageUrl { get; set; }

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
    /// 不懂
    /// </summary>
    [JsonPropertyName("isConcluded")]
    public bool IsConcluded { get; set; }

    /// <summary>
    /// 系列标题
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 介绍
    /// </summary>
    [JsonPropertyName("caption")]
    public string Caption { get; set; }

    /// <summary>
    /// 语言，不一定可靠
    /// </summary>
    [JsonPropertyName("language")]
    public string Language { get; set; }

    /// <summary>
    /// 章节数
    /// </summary>
    [JsonPropertyName("publishedContentCount")]
    public int PublishedContentCount { get; set; }

    /// <summary>
    /// 总字符数
    /// </summary>
    [JsonPropertyName("publishedTotalCharacterCount")]
    public int PublishedTotalCharacterCount { get; set; }

    /// <summary>
    /// 总文字数
    /// </summary>
    [JsonPropertyName("publishedTotalWordCount")]
    public int PublishedTotalWordCount { get; set; }

    /// <summary>
    /// 总阅读时间，单位秒
    /// </summary>
    [JsonPropertyName("publishedReadingTime")]
    public int PublishedReadingTime { get; set; }

    /// <summary>
    /// 上一章节发布时的时间戳
    /// </summary>
    [JsonPropertyName("lastPublishedContentTimestamp")]
    public int LastPublishedContentTimestamp { get; set; }

    /// <summary>
    /// 创建时间戳
    /// </summary>
    [JsonPropertyName("createdTimestamp")]
    public int CreatedTimestamp { get; set; }

    /// <summary>
    /// 上传时间戳
    /// </summary>
    [JsonPropertyName("updatedTimestamp")]
    public int UpdatedTimestamp { get; set; }

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
    /// 第一章的小说id
    /// </summary>
    [JsonPropertyName("firstNovelId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int FirstNovelId { get; set; }

    /// <summary>
    /// 最后一张的小说id
    /// </summary>
    [JsonPropertyName("latestNovelId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int LatestNovelId { get; set; }

    /// <summary>
    /// 可显示章节数
    /// </summary>
    [JsonPropertyName("displaySeriesContentCount")]
    public int DisplaySeriesContentCount { get; set; }

    /// <summary>
    /// 章节数
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// 已追更
    /// </summary>
    [JsonPropertyName("isWatched")]
    public bool IsWatched { get; set; }

    /// <summary>
    /// 已加入追更通知
    /// </summary>
    [JsonPropertyName("isNotifying")]
    public bool IsNotifying { get; set; }

    /// <summary>
    /// 封面，使用 <see cref="CoverUrls"/> 代替
    /// </summary>
    [JsonInclude, JsonPropertyName("cover")]
    public NovelSeriesCoverUrlsWrapper _cover;

    /// <summary>
    /// 不同尺寸的封面
    /// </summary>
    [JsonIgnore]
    public NovelCoverUrls CoverUrls => _cover.Urls;

    /// <summary>
    /// 封面图片包装
    /// </summary>
    public class NovelSeriesCoverUrlsWrapper
    {
        [JsonPropertyName("urls")]
        public NovelCoverUrls Urls { get; set; }
    }
}
