using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.Illust;

internal class MangaSeriesResponse
{
    [JsonPropertyName("thumbnails")]
    public Thumbnails Thumbnails { get; set; }

    [JsonPropertyName("illustSeries")]
    public List<MangaSeries> MangaSeries { get; set; }

    [JsonPropertyName("page")]
    public IllustSeriesWorkWrapper Page { get; set; }

}


internal class IllustSeriesWorkWrapper
{
    [JsonPropertyName("series")]
    public List<IllustSeriesWork> Works { get; set; }

    [JsonPropertyName("isSetCover")]
    public bool IsSetCover { get; set; }

    [JsonPropertyName("seriesId")]
    public int SeriesId { get; set; }

    [JsonPropertyName("otherSeriesId")]
    public string OtherSeriesId { get; set; }

    [JsonPropertyName("recentUpdatedWorkIds")]
    public List<int> RecentUpdatedWorkIds { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("isWatched")]
    public bool IsWatched { get; set; }

    [JsonPropertyName("isNotifying")]
    public bool IsNotifying { get; set; }
}

internal class IllustSeriesWork
{
    [JsonPropertyName("workId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int WorkId { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }
}