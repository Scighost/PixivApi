namespace Scighost.PixivApi.Common;


/// <summary>
/// 作品的标签原始信息，对应的json结构有些复杂，为了减少实体类的数量，此类在不同情况下的有效属性不同。
/// <para />
/// 作者以外的其他用户也可以给作品添加标签，编辑标签后会发送通知给作者，作者可以接受并锁定标签使之不可编辑，也可以锁定作品的全部标签。
/// <para />
/// 当从 <see cref="IllustInfo.OriginalTag"/> 和 <see cref="NovelInfo.IsOriginal"/> 访问此类时，此类表示作品的整体标签信息，此时有效的属性为 <see cref="AuthorId"/>，<see cref="IsLocked"/>，<see cref="Tags"/>，<see cref="Writable"/>。
/// <para />
/// 当从此类的 <see cref="Tags"/> 属性访问此类时，此类表示作品的每一个标签，此时有效的属性为 <see cref="Tag"/>，<see cref="Locked"/>，<see cref="Deletable"/>，<see cref="UserId"/>，<see cref="UserName"/>，<see cref="Translation"/>。
/// </summary>
public class PixivTag
{

    /// <summary>
    /// 作者的uid
    /// </summary>
    [JsonPropertyName("authorId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int AuthorId { get; set; }


    /// <summary>
    /// 标签是否被作者锁定
    /// </summary>
    [JsonPropertyName("isLocked")]
    public bool IsLocked { get; set; }

    /// <summary>
    /// 标签内容
    /// </summary>
    [JsonPropertyName("tags")]
    public List<PixivTag> Tags { get; set; }

    /// <summary>
    /// 标签是否可更改
    /// </summary>
    [JsonPropertyName("writable")]
    public bool Writable { get; set; }



    /// <summary>
    /// 标签名
    /// </summary>
    [JsonPropertyName("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// 是否锁定
    /// </summary>
    [JsonPropertyName("locked")]
    public bool Locked { get; set; }


    /// <summary>
    /// 可删除
    /// </summary>
    [JsonPropertyName("deletable")]
    public bool Deletable { get; set; }

    /// <summary>
    /// 添加标签的用户uid
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    /// <summary>
    /// 添加标签的用户名
    /// </summary>
    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    /// <summary>
    /// 标签翻译
    /// </summary>
    [JsonPropertyName("translation")]
    public TagTranslation Translation { get; set; }


}


/// <summary>
/// 标签翻译
/// </summary>
public class TagTranslation
{
    [JsonPropertyName("en")]
    public string Translation { get; set; }
}

