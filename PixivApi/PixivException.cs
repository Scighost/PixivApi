namespace Scighost.PixivApi;

/// <summary>
/// Pixiv Api 的 StatsCode=200，但是返回内容标记为错误时，抛出此异常
/// </summary>
public class PixivException : Exception
{

    public PixivException(string? message) : base(message) { }

}
