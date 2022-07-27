namespace Scighost.PixivApi.Illust;

/// <summary>
/// 动图元数据，P站的动图就是一个图片序列，打包成一个zip文件。zip文件内的根目录下就是图片序列，文件名如 000000.jpg，000001.jpg。
/// </summary>
public class AnimateIllustMeta
{

    /// <summary>
    /// 插画id
    /// </summary>
    [JsonIgnore]
    public int IllustId { get; set; }

    /// <summary>
    /// 小尺寸动图的zip文件url
    /// </summary>
    [JsonPropertyName("src")]
    public string SmallUrl { get; set; }

    /// <summary>
    /// 大尺寸动图的zip文件url
    /// </summary>
    [JsonPropertyName("originalSrc")]
    public string OriginalUrl { get; set; }

    /// <summary>
    /// Mime type
    /// </summary>
    [JsonPropertyName("mime_type")]
    public string MimeType { get; set; }

    /// <summary>
    /// 动图帧信息
    /// </summary>
    [JsonPropertyName("frames")]
    public List<AnimateIllustFrame> Frames { get; set; }


}

/// <summary>
/// 动图帧信息，包括文件名和帧延迟
/// </summary>
public class AnimateIllustFrame
{
    /// <summary>
    /// 文件名，例如 000000.jpg
    /// </summary>
    [JsonPropertyName("file")]
    public string File { get; set; }

    /// <summary>
    /// 帧延迟，单位毫秒
    /// </summary>
    [JsonPropertyName("delay")]
    public int Delay { get; set; }
}