namespace Scighost.PixivApi.Illust;

/// <summary>
/// 不同尺寸的图片文件地址
/// </summary>
public class IllustImageUrls
{
    /// <summary>
    /// 48x48，从 <see cref="IllustInfo.Urls"/> 访问时可用
    /// </summary>
    [JsonPropertyName("mini")]
    public string? Mini { get; set; }

    /// <summary>
    /// 250x250，从 <see cref="IllustInfo.Urls"/> 访问时可用，应使用 <see cref="Thumb"/> 代替
    /// </summary>
    [JsonInclude, JsonPropertyName("thumb")]
    public string _thumb;

    /// <summary>
    /// 250x250，从 <see cref="IllustImage.Urls"/> 访问时可用，应使用 <see cref="Thumb"/> 代替
    /// </summary>
    [JsonInclude, JsonPropertyName("thumb_mini")]
    public string _thumbMini;

    /// <summary>
    /// 250x250
    /// </summary>
    [JsonIgnore]
    public string Thumb => _thumb + _thumbMini;

    /// <summary>
    /// 540x540
    /// </summary>
    [JsonPropertyName("small")]
    public string Small { get; set; }

    /// <summary>
    /// 1200x1200
    /// </summary>
    [JsonPropertyName("regular")]
    public string Middle { get; set; }

    /// <summary>
    /// 原图
    /// </summary>
    [JsonPropertyName("original")]
    public string Original { get; set; }
}
