namespace Scighost.PixivApi.User;


/// <summary>
/// 用户信息
/// </summary>
public class UserInfo
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
    /// 用户个人背景，此值为 null ，api 已不再能获取到背景图
    /// </summary>
    [JsonPropertyName("background")]
    public UserBackground? Background { get; set; }

    /// <summary>
    /// 该用户的关注用户数
    /// </summary>
    [JsonPropertyName("following")]
    public int FollowingCount { get; set; }

    /// <summary>
    /// 不懂
    /// </summary>
    [JsonPropertyName("followedBack")]
    public bool FollowedBack { get; set; }

    /// <summary>
    /// 个人介绍
    /// </summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    /// <summary>
    /// 个人介绍，html格式
    /// </summary>
    [JsonPropertyName("commentHtml")]
    public string CommentHtml { get; set; }

    /// <summary>
    /// 不懂
    /// </summary>
    [JsonPropertyName("webpage")]
    public string Webpage { get; set; }

    /// <summary>
    /// 不懂
    /// </summary>
    [JsonPropertyName("official")]
    public bool Official { get; set; }

    /// <summary>
    /// 群组
    /// </summary>
    [JsonPropertyName("group")]
    public object Group { get; set; }
}


/// <summary>
/// 用户个人背景图
/// </summary>
public class UserBackground
{
    [JsonPropertyName("repeat")]
    public object Repeat { get; set; }

    [JsonPropertyName("color")]
    public object Color { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("isPrivate")]
    public bool IsPrivate { get; set; }
}