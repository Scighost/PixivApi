using Scighost.PixivApi.Common;
using System.Text.Json.Nodes;

namespace Scighost.PixivApi.User;

/// <summary>
/// 用户的所有作品
/// </summary>
public class UserAllWorks
{

    /// <summary>
    /// 插画作品id
    /// </summary>
    [JsonPropertyName("illusts")]
    [JsonConverter(typeof(DictionaryKeyToListJsonConverter<int>))]
    public List<int> Illusts { get; set; }

    /// <summary>
    /// 漫画作品id
    /// </summary>
    [JsonPropertyName("manga")]
    [JsonConverter(typeof(DictionaryKeyToListJsonConverter<int>))]
    public List<int> Manga { get; set; }

    /// <summary>
    /// 小说作品id
    /// </summary>
    [JsonPropertyName("novels")]
    [JsonConverter(typeof(DictionaryKeyToListJsonConverter<int>))]
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

}
