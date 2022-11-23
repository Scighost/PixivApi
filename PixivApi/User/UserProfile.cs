namespace Scighost.PixivApi.User;

/// <summary>
/// 用户简单信息
/// </summary>
public class UserProfile
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
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// 头像小图
    /// </summary>
    [JsonPropertyName("image")]
    public string Image { get; set; }

    /// <summary>
    /// 头像大图
    /// </summary>
    [JsonPropertyName("imageBig")]
    public string ImageBig { get; set; }

    /// <summary>
    /// 高级会员
    /// </summary>
    [JsonPropertyName("premium")]
    public bool Premium { get; set; }

    /// <summary>
    /// 已关注
    /// </summary>
    [JsonPropertyName("isFollowed")]
    public bool IsFollowed { get; set; }

    /// <summary>
    /// 我的好P友
    /// </summary>
    [JsonPropertyName("isMypixiv")]
    public bool IsMypixiv { get; set; }

    /// <summary>
    /// 已拉黑
    /// </summary>
    [JsonPropertyName("isBlocking")]
    public bool IsBlocking { get; set; }

    /// <summary>
    /// 个人介绍
    /// </summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; }

     /// <summary>
    /// 不懂
    /// </summary>
    [JsonPropertyName("followedBack")]
    public bool FollowedBack { get; set; }

    /// <summary>
    /// 接受约稿
    /// </summary>
    [JsonPropertyName("acceptRequest")]
    public bool AcceptRequest { get; set; }

}