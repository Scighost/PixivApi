namespace Scighost.PixivApi.Illust;


/// <summary>
/// 漫画系列
/// </summary>
public class MangaSeries
{
    /// <summary>
    /// 漫画系列id
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
    /// 漫画系列标题
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 介绍
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// 介绍
    /// </summary>
    [JsonPropertyName("caption")]
    public string Caption { get; set; }

    /// <summary>
    /// 章节数
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// 漫画系列封面图片
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// 第一章的插画id
    /// </summary>
    [JsonPropertyName("firstIllustId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int FirstIllustId { get; set; }


    /// <summary>
    /// 最后一章的插画id
    /// </summary>
    [JsonPropertyName("latestIllustId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int LatestIllustId { get; set; }

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
    /// 漫画系列的内容
    /// </summary>
    public List<MangaSeriesIllust> Illusts { get; set; }

}


/// <summary>
/// 漫画系列的内容
/// </summary>
public class MangaSeriesIllust
{
    /// <summary>
    /// 漫画 id
    /// </summary>
    public int IllustId { get; set; }

    /// <summary>
    /// 在系列中的排序
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// 漫画信息
    /// </summary>
    public IllustProfile IllustProfile { get; set; }
}