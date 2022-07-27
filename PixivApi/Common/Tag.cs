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

    public Tag() { }

    public Tag(string name, string? translation)
    {
        Name = name;
        Translation = translation;
    }
}
