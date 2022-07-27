namespace Scighost.PixivApi.Common;

internal class Thumbnails
{
    [JsonPropertyName("illust")]
    public List<IllustProfile> Illusts { get; set; }

    [JsonPropertyName("novel")]
    public List<NovelProfile> Novels { get; set; }
}