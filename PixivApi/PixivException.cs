namespace Scighost.PixivApi;

/// <summary>
/// 请求 Pixiv Api 时，如果 HTTP StatsCode=200，但是返回内容标记为错误时，抛出此异常。
/// </summary>
public class PixivException : Exception
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public PixivException(string? message) : base(message) { }

}
