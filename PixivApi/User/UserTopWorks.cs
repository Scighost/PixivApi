using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.User;

/// <summary>
/// 用户最近的作品
/// </summary>
public class UserTopWorks
{

    /// <summary>
    /// 插画
    /// </summary>
    [JsonPropertyName("illusts")]
    [JsonConverter(typeof(DictionaryValueToListJsonConverter<int, IllustProfile>))]
    public List<IllustProfile> Illusts { get; set; }


    /// <summary>
    /// 漫画
    /// </summary>
    [JsonPropertyName("manga")]
    [JsonConverter(typeof(DictionaryValueToListJsonConverter<int, IllustProfile>))]
    public List<IllustProfile> Mangas { get; set; }


    /// <summary>
    /// 小说
    /// </summary>
    [JsonPropertyName("novels")]
    [JsonConverter(typeof(DictionaryValueToListJsonConverter<int, NovelProfile>))]
    public List<NovelProfile> Novels { get; set; }

}
