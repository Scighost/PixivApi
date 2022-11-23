using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Novel;

/// <summary>
/// 小说详细信息（有正文）
/// </summary>
public class NovelInfo : IJsonOnDeserialized
{
    /// <summary>
    /// 小说id
    /// </summary>
    [JsonPropertyName("id"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Id { get; set; }

    /// <summary>
    /// 小说标题
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 介绍，html格式
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 收藏数
    /// </summary>
    [JsonPropertyName("bookmarkCount")]
    public int BookmarkCount { get; set; }

    /// <summary>
    /// 评论数
    /// </summary>
    [JsonPropertyName("commentCount")]
    public int CommentCount { get; set; }

    /// <summary>
    /// 书签数
    /// </summary>
    [JsonPropertyName("markerCount")]
    public int MarkerCount { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonPropertyName("createDate")]
    public DateTimeOffset CreateDate { get; set; }

    /// <summary>
    /// 上传时间
    /// </summary>
    [JsonPropertyName("uploadDate")]
    public DateTimeOffset UploadDate { get; set; }

    /// <summary>
    /// 点赞数
    /// </summary>
    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; }

    /// <summary>
    /// 小说页数，正文 <see cref="Content"/> 中, 以 "[newpage]" 分割
    /// </summary>
    [JsonPropertyName("pageCount")]
    public int PageCount { get; set; }

    /// <summary>
    /// 作者uid
    /// </summary>
    [JsonPropertyName("userId"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int UserId { get; set; }

    /// <summary>
    /// 作者昵称
    /// </summary>
    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    /// <summary>
    /// 观看数
    /// </summary>
    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; }

    /// <summary>
    /// 限制级别
    /// </summary>
    [JsonPropertyName("xRestrict")]
    public XRestrict XRestrict { get; set; }

    /// <summary>
    /// 正文
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; }

    /// <summary>
    /// 封面图片
    /// </summary>
    [JsonPropertyName("coverUrl")]
    public string CoverUrl { get; set; }

    /// <summary>
    /// 已点赞
    /// </summary>
    [JsonPropertyName("likeData")]
    public bool IsLike { get; set; }

    /// <summary>
    /// 原始标签，结构比较复杂，请使用 <see cref="Tags"/> 代替
    /// </summary>
    [JsonInclude, JsonPropertyName("tags")]
    public PixivTag OriginalTag;

    /// <summary>
    /// 简单标签
    /// </summary>
    [JsonIgnore]
    public List<Tag> Tags { get; set; }

    /// <summary>
    /// 小说阅读界面的侧栏系列数据
    /// </summary>
    [JsonPropertyName("seriesNavData")]
    public SeriesNavData? SeriesNavData { get; set; }

    /// <summary>
    /// 作者的所有小说的id，请使用 <see cref="UserNovels"/> 代替
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("userNovels")]
    [JsonConverter(typeof(DictionaryJsonConverter<NovelProfile?>))]
    public Dictionary<int, NovelProfile?> _UserNovels;

    /// <summary>
    /// 作者的所有小说的id
    /// </summary>
    public List<int> UserNovels { get; set; }

    /// <summary>
    /// 语言，不一定可靠
    /// </summary>
    [JsonPropertyName("language")]
    public string Language { get; set; }

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
    /// 原创
    /// </summary>
    [JsonPropertyName("isOriginal")]
    public bool IsOriginal { get; set; }

    /// <summary>
    /// 收藏信息，为 null 时未收藏
    /// </summary>
    [JsonPropertyName("bookmarkData")]
    public BookmarkData? BookmarkData { get; set; }

    /// <summary>
    /// 第几页有书签，为 null 时无书签
    /// </summary>
    [JsonPropertyName("marker")]
    public int? Marker { get; set; }

    /// <summary>
    /// 反序列化时的操作，不要直接调用
    /// </summary>
    [Obsolete("反序列化时的操作，不要直接调用")]
    public void OnDeserialized()
    {
        Tags = OriginalTag.Tags.Select(x => new Tag(x.Tag, x.Translation?.Translation)).ToList();
        UserNovels = _UserNovels.Select(x => x.Key).OrderBy(x => x).ToList();
    }
}

