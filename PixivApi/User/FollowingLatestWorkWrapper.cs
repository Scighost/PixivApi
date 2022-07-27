using Scighost.PixivApi.Common;

namespace Scighost.PixivApi.User;


internal class FollowingLatestWorkWrapper
{

    [JsonPropertyName("thumbnails")]
    public Thumbnails Thumbnails { get; set; }
}

