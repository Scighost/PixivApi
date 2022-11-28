namespace Scighost.PixivApi.Illust;

/// <summary>
/// 插画类型，插画/漫画/动图
/// </summary>
public enum IllustType
{
    /// <summary>
    /// 插画
    /// </summary>
    Illustration,

    /// <summary>
    /// 漫画
    /// </summary>
    Manga,

    /// <summary>
    /// 动图
    /// </summary>
    Animation,
}

public enum IllustDownloadType
{
    Original,
    Regular,
    Small,
    Mini,
    Thumb
}
