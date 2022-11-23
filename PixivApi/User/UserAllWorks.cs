using Scighost.PixivApi.Common;
using System.Text.Json.Nodes;

namespace Scighost.PixivApi.User;

/// <summary>
/// 用户的所有作品
/// </summary>
public class UserAllWorks : IJsonOnDeserialized
{
    /// <summary>
    /// 插画作品id，请使用 <see cref="Illusts"/> 代替
    /// </summary>
    [JsonInclude, JsonPropertyName("illusts")]
    [JsonConverter(typeof(DictionaryJsonConverter<object?>))]
    public Dictionary<int, object?> _illusts;

    /// <summary>
    /// 插画作品id
    /// </summary>
    [JsonIgnore]
    public List<int> Illusts { get; set; }

    /// <summary>
    /// 漫画作品id，请使用 <see cref="Manga"/> 代替
    /// </summary>
    [JsonInclude, JsonPropertyName("manga")]
    [JsonConverter(typeof(DictionaryJsonConverter<object?>))]
    public Dictionary<int, object?> _manga;

    /// <summary>
    /// 漫画作品id
    /// </summary>
    [JsonIgnore]
    public List<int> Manga { get; set; }

    /// <summary>
    /// 小说作品id，请使用 <see cref="Novels"/> 代替
    /// </summary>
    [JsonInclude, JsonPropertyName("novels")]
    [JsonConverter(typeof(DictionaryJsonConverter<object?>))]
    public Dictionary<int, object?> _novels;

    /// <summary>
    /// 小说作品id
    /// </summary>
    [JsonIgnore]
    public List<int> Novels { get; set; }

    /// <summary>
    /// 漫画系列
    /// </summary>
    [JsonPropertyName("mangaSeries")]
    public List<MangaSeries> MangaSeries { get; set; }

    /// <summary>
    /// 小说系列
    /// </summary>
    [JsonPropertyName("novelSeries")]
    public List<NovelSeries> NovelSeries { get; set; }

    /// <summary>
    /// 精选作品，结构太复杂，不用实体类表示
    /// </summary>
    [JsonPropertyName("pickup")]
    public List<JsonNode> Pickup { get; set; }

    /// <summary>
    /// 反序列化时的操作，不要直接调用
    /// </summary>
    [Obsolete("反序列化时的操作，不要直接调用")]
    public void OnDeserialized()
    {
        Illusts = _illusts.Select(x => x.Key).ToList();
        Manga = _manga.Select(x => x.Key).ToList();
        Novels = _novels.Select(x => x.Key).ToList();
    }
}
