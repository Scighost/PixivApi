namespace Scighost.PixivApi.Novel;

internal class RecommendNovelWrapper
{

    [JsonPropertyName("novels")]
    public List<NovelProfile> Novels { get; set; }


    [JsonPropertyName("nextIds")]
    public List<string> NextIds { get; set; }

}
