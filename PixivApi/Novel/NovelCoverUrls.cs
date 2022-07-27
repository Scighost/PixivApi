namespace Scighost.PixivApi.Novel;

/// <summary>
/// 小说封面图片
/// </summary>
public class NovelCoverUrls
{
    /// <summary>
    /// 128x128
    /// </summary>
    [JsonPropertyName("128x128")]
    public string Mini { get; set; }

    /// <summary>
    /// 240x240
    /// </summary>
    [JsonPropertyName("240mw")]
    public string Thumb { get; set; }

    /// <summary>
    /// 480x480
    /// </summary>
    [JsonPropertyName("480mw")]
    public string Small { get; set; }

    /// <summary>
    /// 1200x1200
    /// </summary>
    [JsonPropertyName("1200x1200")]
    public string Middle { get; set; }

    /// <summary>
    /// 原图
    /// </summary>
    [JsonPropertyName("original")]
    public string Original { get; set; }
}
