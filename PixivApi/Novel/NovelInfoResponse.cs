using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Novel;

/// <summary>
/// 小说详情的全部字段
/// </summary>
[Obsolete("Not used.")]
internal class NovelInfoResponse
{
    [JsonPropertyName("bookmarkCount")]
    public int BookmarkCount { get; set; }

    [JsonPropertyName("commentCount")]
    public int CommentCount { get; set; }

    [JsonPropertyName("markerCount")]
    public int MarkerCount { get; set; }

    [JsonPropertyName("createDate")]
    public DateTimeOffset CreateDate { get; set; }

    [JsonPropertyName("uploadDate")]
    public DateTimeOffset UploadDate { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("id")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("likeCount")]
    public int LikeCount { get; set; }

    [JsonPropertyName("pageCount")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int PageCount { get; set; }

    [JsonPropertyName("userId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int UserId { get; set; }

    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    [JsonPropertyName("viewCount")]
    public int ViewCount { get; set; }

    [JsonPropertyName("isOriginal")]
    public bool IsOriginal { get; set; }

    [JsonPropertyName("isBungei")]
    public bool IsBungei { get; set; }

    [JsonPropertyName("xRestrict")]
    public XRestrict XRestrict { get; set; }

    [JsonPropertyName("restrict")]
    public int Restrict { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("coverUrl")]
    public string CoverUrl { get; set; }

    [JsonPropertyName("suggestedSettings")]
    public object SuggestedSettings { get; set; }

    [JsonPropertyName("isBookmarkable")]
    public bool IsBookmarkable { get; set; }

    [JsonPropertyName("bookmarkData")]
    public BookmarkData? BookmarkData { get; set; }

    [JsonPropertyName("likeData")]
    public bool LikeData { get; set; }

    [JsonPropertyName("pollData")]
    public object PollData { get; set; }

    /// <summary>
    /// 在文章的第几页添加了书签
    /// </summary>
    [JsonPropertyName("marker")]
    public int? Marker { get; set; }

    [JsonPropertyName("tags")]
    public PixivTag Tags { get; set; }

    [JsonPropertyName("seriesNavData")]
    public SeriesNavData SeriesNavData { get; set; }

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

    [JsonPropertyName("contestData")]
    public object ContestData { get; set; }

    [JsonPropertyName("request")]
    public object Request { get; set; }

    [JsonPropertyName("imageResponseOutData")]
    public List<object> ImageResponseOutData { get; set; }

    [JsonPropertyName("imageResponseData")]
    public List<object> ImageResponseData { get; set; }

    [JsonPropertyName("imageResponseCount")]
    public int ImageResponseCount { get; set; }

    [JsonPropertyName("userNovels")]
    [JsonConverter(typeof(DictionaryJsonConverter<NovelProfile?>))]
    public Dictionary<int, NovelProfile?> UserNovels { get; set; }

    [JsonPropertyName("hasGlossary")]
    public bool HasGlossary { get; set; }

    [JsonPropertyName("zoneConfig")]
    public object ZoneConfig { get; set; }

    [JsonPropertyName("extraData")]
    public object ExtraData { get; set; }

    [JsonPropertyName("titleCaptionTranslation")]
    public object TitleCaptionTranslation { get; set; }

    [JsonPropertyName("isUnlisted")]
    public bool IsUnlisted { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("textEmbeddedImages")]
    public object TextEmbeddedImages { get; set; }

    [JsonPropertyName("commentOff")]
    public int CommentOff { get; set; }

    [JsonPropertyName("characterCount")]
    public int CharacterCount { get; set; }

    [JsonPropertyName("wordCount")]
    public int WordCount { get; set; }

    [JsonPropertyName("useWordCount")]
    public bool UseWordCount { get; set; }

    [JsonPropertyName("readingTime")]
    public int ReadingTime { get; set; }
}
