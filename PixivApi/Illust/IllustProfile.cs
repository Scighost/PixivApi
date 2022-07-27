using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Illust;


/// <summary>
/// 插画漫画的简单信息
/// </summary>
public class IllustProfile
{
    /// <summary>
    /// 作品id
    /// </summary>
    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int Id { get; set; }

    /// <summary>
    /// 作品标题
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 作品类型，插画 or 漫画
    /// </summary>
    [JsonPropertyName("illustType")]
    public IllustType IllustType { get; set; }

    /// <summary>
    /// 限制级别
    /// </summary>
    [JsonPropertyName("xRestrict")]
    public int XRestrict { get; set; }

    /// <summary>
    /// 第一张图片的地址
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// 介绍，html格式
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 作品原始标签，未翻译
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
    /// 作品的图片数量
    /// </summary>
    [JsonPropertyName("pageCount")]
    public int PageCount { get; set; }

    /// <summary>
    /// 收藏信息，为 null 时未收藏
    /// </summary>
    [JsonPropertyName("bookmarkData")]
    public BookmarkData? BookmarkData { get; set; }

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
    /// 用户头像图片地址
    /// </summary>
    [JsonPropertyName("profileImageUrl")]
    public string UserProfileImageUrl { get; set; }

}