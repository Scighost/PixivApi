using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Illust;

/// <summary>
/// 插画漫画详情的全部字段
/// </summary>
[Obsolete("Not used.")]
internal class IllustInfoResponse
{
    [JsonPropertyName("illustId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int IllustId { get; set; }

    [JsonPropertyName("illustTitle")]
    public string IllustTitle { get; set; }

    [JsonPropertyName("illustComment")]
    public string IllustComment { get; set; }

    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("illustType")]
    public IllustType IllustType { get; set; }

    [JsonPropertyName("createDate")]
    public DateTimeOffset CreateDate { get; set; }

    [JsonPropertyName("uploadDate")]
    public DateTimeOffset UploadDate { get; set; }

    [JsonPropertyName("restrict")]
    public int Restrict { get; set; }

    [JsonPropertyName("xRestrict")]
    public XRestrict XRestrict { get; set; }

    [JsonPropertyName("sl")]
    public int Sl { get; set; }

    [JsonPropertyName("urls")]
    public IllustImageUrls Urls { get; set; }

    [JsonPropertyName("tags")]
    public PixivTagInternal Tags { get; set; }

    [JsonPropertyName("alt")]
    public string Alt { get; set; }

    [JsonPropertyName("storableTags")]
    public List<string> StorableTags { get; set; }

    [JsonPropertyName("userId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int UserId { get; set; }

    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    [JsonPropertyName("userAccount")]
    public string UserAccount { get; set; }

    [JsonPropertyName("userIllusts")]
    public Dictionary<int, IllustProfile?> UserIllusts { get; set; }

    [JsonPropertyName("likeData")]
    public bool LikeData { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("pageCount")]
    public int PageCount { get; set; }

    [JsonPropertyName("bookmarkCount")]
    public int BookmarkCount { get; set; }

    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; }

    [JsonPropertyName("commentCount")]
    public int CommentCount { get; set; }

    [JsonPropertyName("responseCount")]
    public int ResponseCount { get; set; }

    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; }

    [JsonPropertyName("bookStyle")]
    public int BookStyle { get; set; }

    [JsonPropertyName("isHowto")]
    public bool IsHowto { get; set; }

    [JsonPropertyName("isOriginal")]
    public bool IsOriginal { get; set; }

    [JsonPropertyName("imageResponseOutData")]
    public List<object> ImageResponseOutData { get; set; }

    [JsonPropertyName("imageResponseData")]
    public List<object> ImageResponseData { get; set; }

    [JsonPropertyName("imageResponseCount")]
    public int ImageResponseCount { get; set; }

    [JsonPropertyName("pollData")]
    public object PollData { get; set; }

    [JsonPropertyName("seriesNavData")]
    public object SeriesNavData { get; set; }

    [JsonPropertyName("descriptionBoothId")]
    public object DescriptionBoothId { get; set; }

    [JsonPropertyName("descriptionYoutubeId")]
    public object DescriptionYoutubeId { get; set; }

    [JsonPropertyName("comicPromotion")]
    public object ComicPromotion { get; set; }

    [JsonPropertyName("fanboxPromotion")]
    public object FanboxPromotion { get; set; }

    [JsonPropertyName("contestBanners")]
    public List<object> ContestBanners { get; set; }

    [JsonPropertyName("isBookmarkable")]
    public bool IsBookmarkable { get; set; }

    [JsonPropertyName("bookmarkData")]
    public BookmarkData? BookmarkData { get; set; }

    [JsonPropertyName("contestData")]
    public object ContestData { get; set; }

    [JsonPropertyName("zoneConfig")]
    public object ZoneConfig { get; set; }

    [JsonPropertyName("extraData")]
    public object ExtraData { get; set; }

    [JsonPropertyName("titleCaptionTranslation")]
    public object TitleCaptionTranslation { get; set; }

    [JsonPropertyName("isUnlisted")]
    public bool IsUnlisted { get; set; }

    [JsonPropertyName("request")]
    public object Request { get; set; }

    [JsonPropertyName("commentOff")]
    public int CommentOff { get; set; }
}
