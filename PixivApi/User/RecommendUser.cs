using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.User;

/// <summary>
/// 推荐的用户
/// </summary>
public class RecommendUser : UserProfile
{
    /// <summary>
    /// 插画作品
    /// </summary>
    [JsonIgnore]
    public List<IllustProfile> Illusts { get; set; }

    /// <summary>
    /// 小说作品
    /// </summary>
    [JsonIgnore]
    public List<NovelProfile> Novels { get; set; }
}


internal class RecommendUserResponse
{

    [JsonPropertyName("recommendUsers")]
    public List<RecommendMap> RecommendMaps { get; set; }

    [JsonPropertyName("thumbnails")]
    public Thumbnails Thumbnails { get; set; }

    [JsonPropertyName("users")]
    public List<RecommendUser> Users { get; set; }

}


internal class RecommendMap
{
    [JsonPropertyName("userId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int UserId { get; set; }

    [JsonPropertyName("illustIds")]
    public List<string> IllustIds { get; set; }

    [JsonPropertyName("novelIds")]
    public List<string> NovelIds { get; set; }
}
