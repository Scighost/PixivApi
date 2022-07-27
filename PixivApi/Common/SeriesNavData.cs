namespace Scighost.PixivApi.Common;


/// <summary>
/// 漫画或小说阅读时的侧栏系列数据
/// </summary>
public class SeriesNavData
{
    /// <summary>
    /// 漫画或小说，"manga" or "novel"
    /// </summary>
    [JsonPropertyName("seriesType")]
    public string SeriesType { get; set; }

    /// <summary>
    /// 作品系列id
    /// </summary>
    [JsonPropertyName("seriesId")]
    public int SeriesId { get; set; }

    /// <summary>
    /// 漫画或小说的系列名
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// 不懂
    /// </summary>
    [JsonPropertyName("isConcluded")]
    public bool IsConcluded { get; set; }

    /// <summary>
    /// 不懂
    /// </summary>
    [JsonPropertyName("isReplaceable")]
    public bool IsReplaceable { get; set; }

    /// <summary>
    /// 已追更
    /// </summary>
    [JsonPropertyName("isWatched")]
    public bool IsWatched { get; set; }

    /// <summary>
    /// 已添加到追更通知列表
    /// </summary>
    [JsonPropertyName("isNotifying")]
    public bool IsNotifying { get; set; }

    /// <summary>
    /// 作品在此系列中的位置
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; set; }


    /// <summary>
    /// 系列中的上一个作品
    /// </summary>
    [JsonPropertyName("prev")]
    public SeriesNavDataPreviewOrNextData? Preview { get; set; }

    /// <summary>
    /// 系列中的下一个作品
    /// </summary>
    [JsonPropertyName("next")]
    public SeriesNavDataPreviewOrNextData? Next { get; set; }

}


/// <summary>
/// 作品系列中的上一个或下一个作品
/// </summary>
public class SeriesNavDataPreviewOrNextData
{
    /// <summary>
    /// 可用
    /// </summary>
    [JsonPropertyName("available")]
    public bool Available { get; set; }

    /// <summary>
    /// 作品id
    /// </summary>
    [JsonPropertyName("id"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int Id { get; set; }

    /// <summary>
    /// 作品在此系列中的位置
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }
}