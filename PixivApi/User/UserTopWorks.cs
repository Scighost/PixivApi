using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.User;

/// <summary>
/// 用户最近的作品
/// </summary>
public class UserTopWorks : IJsonOnDeserialized
{
    /// <summary>
    /// 插画，使用 <see cref="Illusts"/> 代替
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("illusts")]
    [JsonConverter(typeof(DictionaryJsonConverter<IllustProfile?>))]
    public Dictionary<int, IllustProfile> _Illusts;

    /// <summary>
    /// 插画
    /// </summary>
    public List<IllustProfile> Illusts { get; set; }

    /// <summary>
    /// 漫画，使用 <see cref="Mangas"/> 代替
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("manga")]
    [JsonConverter(typeof(DictionaryJsonConverter<IllustProfile?>))]
    public Dictionary<int, IllustProfile> _Mangas;

    /// <summary>
    /// 漫画
    /// </summary>
    public List<IllustProfile> Mangas { get; set; }

    /// <summary>
    /// 小说，使用 <see cref="Novels"/> 代替
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("novels")]
    [JsonConverter(typeof(DictionaryJsonConverter<NovelProfile?>))]
    public Dictionary<int, NovelProfile> _Novels;

    /// <summary>
    /// 小说
    /// </summary>
    public List<NovelProfile> Novels { get; set; }

    /// <summary>
    /// 反序列化时的操作，不要直接调用
    /// </summary>
    [Obsolete("反序列化时的操作，不要直接调用")]
    public void OnDeserialized()
    {
        Illusts = _Illusts.Select(x => x.Value).ToList();
        Mangas = _Mangas.Select(x => x.Value).ToList();
        Novels = _Novels.Select(x => x.Value).ToList();
    }
}
