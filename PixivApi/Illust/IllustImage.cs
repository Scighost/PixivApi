namespace Scighost.PixivApi.Illust;

/// <summary>
/// 插画图片
/// </summary>
public class IllustImage
{
    /// <summary>
    /// 不同尺寸的图片文件地址
    /// </summary>
    [JsonPropertyName("urls")]
    public IllustImageUrls Urls { get; set; }

    /// <summary>
    /// 原始大小的像素宽度
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// 原始大小的像素高度
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }
}
