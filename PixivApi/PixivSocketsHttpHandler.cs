using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace Scighost.PixivApi;

/// <summary>
/// 创建用于绕过SNI阻断的 <see cref="HttpClient"/>，只能连接Pixiv的服务器。
/// </summary>
public abstract class PixivSocketsHttpClient
{
    /// <summary>
    /// 创建用于绕过SNI阻断的 <see cref="HttpClient"/>，只能连接Pixiv的服务器。
    /// </summary>
    /// <param name="ip">指定 pixiv api ip</param>
    /// <returns></returns>
    public static HttpClient Create(string? ip = null)
    {
        string host = "www.pixivision.net";
        if (IPAddress.TryParse(ip, out _))
        {
            host = ip;
        }
        var handler = new StandardSocketsHttpHandler
        {            
            AutomaticDecompression = DecompressionMethods.GZip,
            ConnectCallback = async (info, token) =>
            {
                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                await socket.ConnectAsync(host, 443);
                var stream = new NetworkStream(socket, true);
                var sslstream = new SslStream(stream, false, (_, _, _, _) => true);
                // await sslstream.AuthenticateAsClientAsync("");
                // 使用Http2导致请求无法解析
                await sslstream.AuthenticateAsClientAsync(new SslClientAuthenticationOptions
                {
                    TargetHost = "",
                    ApplicationProtocols = new List<SslApplicationProtocol>(new SslApplicationProtocol[] { SslApplicationProtocol.Http11 })
                }, default);
                return sslstream;
            },
        };
        var client = new HttpClient(handler);
        return client;
    }
}
