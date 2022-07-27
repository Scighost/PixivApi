namespace Scighost.PixivApi.Common;

/// <summary>
/// 用户收藏作品的所有自定义标签，标签过多则不会全部包括在内
/// </summary>
public class UserBookmarkTag
{

    /// <summary>
    /// 公开收藏作品的标签
    /// </summary>
    [JsonPropertyName("public")]
    public List<BookmarkTag> Public { get; set; }

    /// <summary>
    /// 不公开收藏作品的标签
    /// </summary>
    [JsonPropertyName("private")]
    public List<BookmarkTag> Private { get; set; }

    /// <summary>
    /// 收藏的作品太多了
    /// </summary>
    [JsonPropertyName("tooManyBookmark")]
    public bool TooManyBookmark { get; set; }

    /// <summary>
    /// 收藏作品的标签太多了
    /// </summary>
    [JsonPropertyName("tooManyBookmarkTags")]
    public bool TooManyBookmarkTags { get; set; }
}


/// <summary>
/// 收藏作品的自定义标签名和对应的作品数量
/// </summary>
public class BookmarkTag
{

    /// <summary>
    /// 标签名
    /// </summary>
    [JsonPropertyName("tag")]
    public string Name { get; set; }

    /// <summary>
    /// 作品数量
    /// </summary>
    [JsonPropertyName("cnt")]
    public int Count { get; set; }

}