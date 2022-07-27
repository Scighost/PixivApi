namespace Scighost.PixivApi.User;

/// <summary>
/// 关注的用户
/// </summary>
public class FollowingUser
{
    /// <summary>
    /// 用户uid
    /// </summary>
    [JsonPropertyName("userId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int UserId { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    /// <summary>
    /// 头像图片
    /// </summary>
    [JsonPropertyName("profileImageUrl")]
    public string UserProfileImageUrl { get; set; }

    /// <summary>
    /// 插画作品
    /// </summary>
    [JsonPropertyName("illusts")]
    public List<IllustProfile> Illusts { get; set; }

    /// <summary>
    /// 小说作品
    /// </summary>
    [JsonPropertyName("novels")]
    public List<NovelProfile> Novels { get; set; }

}

internal class FollowingUserWrapper
{

    [JsonPropertyName("total")]
    public int Total { get; set; }


    [JsonPropertyName("users")]
    public List<FollowingUser> Users { get; set; }

}