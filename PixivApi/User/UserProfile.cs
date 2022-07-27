namespace Scighost.PixivApi.User;

public class UserProfile
{

    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    [JsonPropertyName("followedBack")]
    public bool FollowedBack { get; set; }

    [JsonPropertyName("userId")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
    public int UserId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("imageBig")]
    public string ImageBig { get; set; }

    [JsonPropertyName("premium")]
    public bool Premium { get; set; }

    [JsonPropertyName("isFollowed")]
    public bool IsFollowed { get; set; }

    [JsonPropertyName("isMypixiv")]
    public bool IsMypixiv { get; set; }

    [JsonPropertyName("isBlocking")]
    public bool IsBlocking { get; set; }

    /// <summary>
    /// 接受约稿
    /// </summary>
    [JsonPropertyName("acceptRequest")]
    public bool AcceptRequest { get; set; }


}