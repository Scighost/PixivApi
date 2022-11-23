namespace Scighost.PixivApi.Common;


/// <summary>
/// 简化后的作品标签，原始标签信息请查看 <see cref="PixivTag"/>
/// </summary>
public class Tag
{
    /// <summary>
    /// 标签名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 标签翻译，插画的部分标签没有翻译，小说的所有标签没有翻译
    /// </summary>
    public string? Translation { get; set; }

    /// <summary>
    /// 构造简化后的作品标签
    /// </summary>
    public Tag() { }

    /// <summary>
    /// 构造简化后的作品标签
    /// </summary>
    /// <param name="name">原文</param>
    /// <param name="translation">翻译m</param>
    public Tag(string name, string? translation)
    {
        Name = name;
        Translation = translation;
    }
}
