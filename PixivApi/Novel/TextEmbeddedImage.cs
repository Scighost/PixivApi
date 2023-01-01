namespace Scighost.PixivApi.Novel;

/// <summary>
/// 嵌入小说正文的图片
/// </summary>
public class TextEmbeddedImage
{

    /// <summary>
    /// 图片 id
    /// </summary>
    [JsonPropertyName("novelImageId")]
    public int NovelImageId { get; set; }

    /// <summary>
    /// 图片链接
    /// </summary>
    [JsonPropertyName("urls")]
    public NovelImageUrls Urls { get; set; }
}