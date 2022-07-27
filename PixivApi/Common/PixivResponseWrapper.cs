namespace Scighost.PixivApi.Common;

internal class PixivResponseWrapper<T>
{
    [JsonPropertyName("error")]
    public bool Error { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("body")]
    public T Body { get; set; }
}


