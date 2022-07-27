namespace Scighost.PixivApi.Novel;

internal class BookmarkNovelWrapper
{

    [JsonPropertyName("total")]
    public int Total { get; set; }


    [JsonPropertyName("works")]
    public List<NovelProfile> Works { get; set; }

}