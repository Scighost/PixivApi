using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Illust;

/// <summary>
/// 插画和漫画详细信息，已忽略部分无用字段
/// </summary>
public class IllustInfo : IJsonOnDeserialized
{
    /// <summary>
    /// 插画漫画id
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int Id { get; set; }

    /// <summary>
    /// 插画漫画作品标题
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 介绍，html格式
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 作品类型，插画 or 漫画
    /// </summary>
    [JsonPropertyName("illustType")]
    public IllustType IllustType { get; set; }

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
    /// 限制级别
    /// </summary>
    [JsonPropertyName("xRestrict")]
    public XRestrict XRestrict { get; set; }

    /// <summary>
    /// 第一张图片的不同尺寸的文件地址，作品的更多图片请调用 <see cref="PixivClient.GetIllustPagesAsync(int)"/>
    /// </summary>
    [JsonPropertyName("urls")]
    public IllustImageUrls Urls { get; set; }

    /// <summary>
    /// 作品的原始标签数据，这个类有些复杂，请使用简单标签 <see cref="Tags"/> 代替.
    /// </summary>
    [JsonInclude, JsonPropertyName("tags")]
    public PixivTag OriginalTag;

    /// <summary>
    /// 作品的简单标签
    /// </summary>
    [JsonIgnore]
    public List<Tag> Tags { get; set; }

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
    /// 登录账号的用户名（不是很明白为什么会把这个东西暴露出来）
    /// </summary>
    [JsonPropertyName("userAccount")]
    public string UserAccount { get; set; }

    /// <summary>
    /// 作者的所有插画的id，请使用 <see cref="UserIllusts"/> 代替
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("userIllusts")]
    [JsonConverter(typeof(DictionaryJsonConverter<IllustProfile?>))]
    public Dictionary<int, IllustProfile?> _UserIllusts;

    /// <summary>
    /// 作者的所有插画的id
    /// </summary>
    [JsonIgnore]
    public List<int> UserIllusts { get; set; }

    /// <summary>
    /// 已点赞
    /// </summary>
    [JsonPropertyName("likeData")]
    public bool IsLike { get; set; }

    /// <summary>
    /// 第一张图片的像素宽度
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// 第一张图片的像素高度
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    /// 作品有多少张图片
    /// </summary>
    [JsonPropertyName("pageCount")]
    public int PageCount { get; set; }

    /// <summary>
    /// 收藏数
    /// </summary>
    [JsonPropertyName("bookmarkCount")]
    public int BookmarkCount { get; set; }

    /// <summary>
    /// 点赞数
    /// </summary>
    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; }

    /// <summary>
    /// 评论数
    /// </summary>
    [JsonPropertyName("commentCount")]
    public int CommentCount { get; set; }

    /// <summary>
    /// 不懂
    /// </summary>
    [JsonPropertyName("responseCount")]
    public int ResponseCount { get; set; }

    /// <summary>
    /// 观看数
    /// </summary>
    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; }

    /// <summary>
    /// 是否原创
    /// </summary>
    [JsonPropertyName("isOriginal")]
    public bool IsOriginal { get; set; }

    /// <summary>
    /// 漫画阅读页面的侧栏数据
    /// </summary>
    [JsonPropertyName("seriesNavData")]
    public SeriesNavData? SeriesNavData { get; set; }

    /// <summary>
    /// 收藏信息，为 null 时未收藏
    /// </summary>
    [JsonPropertyName("bookmarkData")]
    public BookmarkData? BookmarkData { get; set; }

    public void OnDeserialized()
    {
        Tags = OriginalTag.Tags.Select(x => new Tag(x.Tag, x.Translation?.Translation)).ToList();
        UserIllusts = _UserIllusts.Select(x => x.Key).OrderBy(x => x).ToList();
    }
}
