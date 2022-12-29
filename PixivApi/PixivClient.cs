using Scighost.PixivApi.Common;
using Scighost.PixivApi.Search;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace Scighost.PixivApi;


/// <summary>
/// Pixiv Api 的请求类，所有请求均从此发出，返回错误内容时会抛出 <see cref="PixivException"/> 。
/// <para />
/// 在构造此类的实例时可以选择使用不同的构造函数，相对应的功能有 HTTP 代理，绕过 SNI 阻断并指定 IP。
/// <para />
/// Pixiv 的登录过程使用了 Cloudflare 保护，基本无法绕过，部分需要账号的功能请在浏览器上登录后使用包含 cookie 和 ua 的构造函数。
/// <para />
/// 在进行关注、收藏等非 GET 操作时，需要先调用此方法 <see cref="GetTokenAsync"/> 获取 token，返回为 true 代表获取成功，建议构造完成后立即调用。
/// </summary>
public class PixivClient
{

    private const string BASE_URI_HTTP = "http://www.pixiv.net/";
    private const string BASE_URI_HTTPS = "https://www.pixiv.net/";
    private const string DEFAULT_USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36 Edg/108.0.1462.54";


    private readonly HttpClient _httpClient;

    /// <summary>
    /// 内部的 HttpClient 实例
    /// </summary>
    public HttpClient HttpClient => _httpClient;


    private string? token;


    #region Constructor


    /// <summary>
    /// 绕过 SNI 阻断
    /// </summary>
    /// <param name="bypassSNI">绕过 SNI 阻断</param>
    /// <param name="ip">直连 ip，若为空则使用 Pixivision 的 IP</param>
    public PixivClient(bool bypassSNI = false, string? ip = null)
    {
        if (bypassSNI)
        {
            _httpClient = PixivSocketsHttpClient.Create(ip);
            _httpClient.BaseAddress = new Uri(BASE_URI_HTTP);
        }
        else
        {
            _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All });
            _httpClient.BaseAddress = new Uri(BASE_URI_HTTPS);
        }
        _httpClient.DefaultRequestHeaders.Add("User-Agent", DEFAULT_USER_AGENT);
        _httpClient.DefaultRequestHeaders.Add("Referer", BASE_URI_HTTPS);
    }


    /// <summary>
    /// 设置 HTTP 代理
    /// </summary>
    /// <param name="httpProxy">HTTP代理</param>
    public PixivClient(string httpProxy)
    {
        _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All, Proxy = new WebProxy(httpProxy) });
        _httpClient.BaseAddress = new Uri(BASE_URI_HTTPS);
        _httpClient.DefaultRequestHeaders.Add("User-Agent", DEFAULT_USER_AGENT);
        _httpClient.DefaultRequestHeaders.Add("Referer", BASE_URI_HTTPS);
    }


    /// <summary>
    /// 使用账号，绕过 SNI 阻断
    /// </summary>
    /// <param name="cookie">账号cookie</param>
    /// <param name="bypassSNI">绕过SNI阻断</param>
    /// <param name="ip">直连ip，若为空则使用Pixivision的IP</param>
    public PixivClient(string cookie, bool bypassSNI = false, string? ip = null)
    {
        if (bypassSNI)
        {
            _httpClient = PixivSocketsHttpClient.Create(ip);
            _httpClient.BaseAddress = new Uri(BASE_URI_HTTP);
        }
        else
        {
            _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All });
            _httpClient.BaseAddress = new Uri(BASE_URI_HTTPS);
        }
        _httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
        _httpClient.DefaultRequestHeaders.Add("User-Agent", DEFAULT_USER_AGENT);
        _httpClient.DefaultRequestHeaders.Add("Referer", BASE_URI_HTTPS);
    }


    /// <summary>
    /// 使用账号，设置 HTTP 代理
    /// </summary>
    /// <param name="cookie">账号cookie</param>
    /// <param name="httpProxy">HTTP代理</param>
    public PixivClient(string cookie, string httpProxy)
    {

        _httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All, Proxy = new WebProxy(httpProxy) });
        _httpClient.BaseAddress = new Uri(BASE_URI_HTTPS);
        _httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
        _httpClient.DefaultRequestHeaders.Add("User-Agent", DEFAULT_USER_AGENT);
        _httpClient.DefaultRequestHeaders.Add("Referer", BASE_URI_HTTPS);
    }


    #endregion



    #region Common Method


    private async Task<T> CommonGetAsync<T>(string url)
    {
        var wrapper = await _httpClient.GetFromJsonAsync<PixivResponseWrapper<T>>(url);
        if (wrapper?.Error ?? true)
        {
            throw new PixivException(wrapper?.Message);
        }
        return wrapper.Body;
    }


    private async Task<T> CommonPostAsync<T>(string url, object value)
    {
        var response = await _httpClient.PostAsJsonAsync(url, value);
        response.EnsureSuccessStatusCode();
        var wrapper = await response.Content.ReadFromJsonAsync<PixivResponseWrapper<T>>();
        if (wrapper?.Error ?? true)
        {
            throw new PixivException(wrapper?.Message);
        }
        return wrapper.Body;
    }


    private async Task<T> CommonSendAsync<T>(HttpRequestMessage message)
    {
        var response = await _httpClient.SendAsync(message);
        response.EnsureSuccessStatusCode();
        var wrapper = await response.Content.ReadFromJsonAsync<PixivResponseWrapper<T>>();
        if (wrapper?.Error ?? true)
        {
            throw new PixivException(wrapper?.Message);
        }
        return wrapper.Body;
    }


    /// <summary>
    /// 在进行关注、收藏等非 GET 操作时，需要先调用此方法获取 token，返回为 true 代表获取成功，建议构造完成后立即调用。
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetTokenAsync()
    {
        if (!string.IsNullOrWhiteSpace(this.token))
        {
            return true;
        }
        var str = await _httpClient.GetStringAsync("/");
        token = Regex.Match(str, @"""token"":""([^""]+)""").Groups[1].Value;
        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Add("x-csrf-token", token);
            return true;
        }
        else
        {
            return false;
        }
    }




    #endregion



    #region User

    /// <summary>
    /// 账号 uid，未使用账号则返回 0
    /// </summary>
    /// <returns>账号uid，未使用账号则返回 0</returns>
    public async Task<int> GetMyUserIdAsync()
    {
        var url = "/";
        var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        if (response.Headers.TryGetValues("x-userid", out var idstr))
        {
            var ids = idstr.FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                if (int.TryParse(ids, out var id))
                {
                    return id;
                }
            }
        }
        return 0;
    }


    /// <summary>
    /// 用户信息
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<UserInfo> GetUserInfoAsyn(int userId)
    {
        var url = $"/ajax/user/{userId}?full=1";
        return await CommonGetAsync<UserInfo>(url);
    }

    /// <summary>
    /// 用户最新的部分作品
    /// </summary>
    /// <returns></returns>
    public async Task<UserTopWorks> GetUserTopWorksAsync(int userId)
    {
        var url = $"/ajax/user/{userId}/profile/top";
        return await CommonGetAsync<UserTopWorks>(url);
    }

    /// <summary>
    /// 用户所有作品id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<UserAllWorks> GetUserAllWorksAsync(int userId)
    {
        var url = $"/ajax/user/{userId}/profile/all";
        return await CommonGetAsync<UserAllWorks>(url);
    }

    #endregion



    #region Illust


    /// <summary>
    /// 插画详情
    /// </summary>
    /// <param name="illustId"></param>
    /// <returns></returns>
    public async Task<IllustInfo> GetIllustInfoAsync(int illustId)
    {
        var url = $"/ajax/illust/{illustId}";
        return await CommonGetAsync<IllustInfo>(url);
    }

    /// <summary>
    /// 插画内所有图片（需登录）
    /// </summary>
    /// <param name="illustId"></param>
    /// <returns></returns>
    public async Task<List<IllustImage>> GetIllustPagesAsync(int illustId)
    {
        var url = $"/ajax/illust/{illustId}/pages";
        return await CommonGetAsync<List<IllustImage>>(url);
    }

    /// <summary>
    /// 动图数据（需登录）
    /// </summary>
    /// <param name="illustId"></param>
    /// <returns></returns>
    public async Task<AnimateIllustMeta> GetAnimateIllustMetaAsync(int illustId)
    {
        var url = $"/ajax/illust/{illustId}/ugoira_meta";
        var data = await CommonGetAsync<AnimateIllustMeta>(url);
        data.IllustId = illustId;
        return data;
    }


    /// <summary>
    /// 漫画系列
    /// </summary>
    /// <param name="seriesId">漫画系列 id</param>
    /// <param name="page">页数，倒序，一页12个</param>
    /// <returns></returns>
    public async Task<MangaSeries> GetMangaSeriesAsync(int seriesId, int page)
    {
        var url = $"/ajax/series/{seriesId}?p={page}";
        var response = await CommonGetAsync<MangaSeriesResponse>(url);
        var manga = response.MangaSeries.First(x => x.Id == seriesId);
        var dic_illuts = response.Thumbnails.Illusts.ToDictionary(x => x.Id);
        var works = response.Page.Works;
        var illusts = new List<MangaSeriesIllust>(works.Count);
        foreach (var work in works)
        {
            if (dic_illuts.TryGetValue(work.WorkId, out var illust))
            {
                illusts.Add(new MangaSeriesIllust { IllustId = work.WorkId, IllustProfile = illust, Order = work.Order });
            }
        }
        manga.Illusts = illusts;
        return manga;
    }



    /// <summary>
    /// 追更漫画系列
    /// </summary>
    /// <param name="mangaSeriesId">小说系列id</param>
    /// <param name="unWatch">取消追更</param>
    /// <returns></returns>
    public async Task WatchMangaSeriesAsync(int mangaSeriesId, bool unWatch = false)
    {
        var url = $"/ajax/illust/series/{mangaSeriesId}/{(unWatch ? "unwatch" : "watch")}";
        await CommonPostAsync<JsonNode>(url, new object());
    }


    /// <summary>
    /// 更改漫画系列追更通知，追更漫画系列后再开启通知
    /// </summary>
    /// <param name="mangaSeriesId">小说系列id</param>
    /// <param name="enable">开启关闭通知</param>
    /// <returns></returns>
    public async Task ChangeMangaSeriesWatchListNotification(int mangaSeriesId, bool enable = false)
    {
        var url = $"/ajax/illust/series/{mangaSeriesId}/watchlist/notification/{(enable ? "turn_on" : "turn_off")}";
        await CommonPostAsync<JsonNode>(url, new object());
    }


    /// <summary>
    /// 插画主页内容
    /// </summary>
    /// <returns></returns>
    private async Task GetIllustHomePageAsync()
    {
        const string url = "/ajax/top/illust?mode=all";
        // todo
    }


    /// <summary>
    /// 漫画主页内容
    /// </summary>
    /// <returns></returns>
    private async Task GetMangaHomePageAsync()
    {
        const string url = "/ajax/top/manga?mode=all";
        // todo
    }


    /// <summary>
    /// 给插画点赞，好像不能取消
    /// </summary>
    /// <param name="illustId"></param>
    /// <returns></returns>
    public async Task LikeIllustAsync(int illustId)
    {
        const string url = "/ajax/illusts/like";
        var obj = new { illust_id = illustId.ToString() };
        await CommonPostAsync<JsonNode>(url, obj);
    }


    /// <summary>
    /// 收藏插画，返回收藏id
    /// </summary>
    /// <param name="illustId">插画id</param>
    /// <param name="isPrivate">不公开</param>
    /// <param name="comment">收藏时附加的评论</param>
    /// <param name="tags">收藏时添加的标签，使用未翻译的原始标签，最多10个</param>
    /// <returns>收藏id</returns>
    public async Task<long> AddBookmarkIllustAsync(int illustId, bool isPrivate = false, string comment = "", params string[] tags)
    {
        var request = new AddBookmarkIllustRequest
        {
            IllustId = illustId,
            IsPrivate = isPrivate,
            Comment = comment,
            Tags = tags.Take(10),
        };
        return await AddBookmarkIllustAsync(request);
    }


    /// <summary>
    /// 收藏插画，返回收藏id
    /// </summary>
    /// <param name="request">收藏请求</param>
    /// <returns>收藏id</returns>
    public async Task<long> AddBookmarkIllustAsync(AddBookmarkIllustRequest request)
    {
        const string url = "/ajax/illusts/bookmarks/add";
        var jsonNode = await CommonPostAsync<JsonNode>(url, request);
        long.TryParse((string?)jsonNode["last_bookmark_id"], out var bookmarkId);
        return bookmarkId;
    }


    /// <summary>
    /// 删除收藏的插画
    /// </summary>
    /// <param name="bookmarkId">收藏id</param>
    /// <returns></returns>
    public async Task DeleteBookmarkIllustAsync(int bookmarkId)
    {
        const string url = "/rpc/index.php";
        var form = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("mode", "delete_illust_bookmark"),
            new KeyValuePair<string, string>("bookmark_id", bookmarkId.ToString())
        };
        var message = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Content = new FormUrlEncodedContent(form),
        };
        await CommonSendAsync<JsonNode>(message);
    }


    /// <summary>
    /// 批量更改收藏插画的公开属性
    /// </summary>
    /// <param name="isPrivate">不公开</param>
    /// <param name="bookmarkIds">收藏id</param>
    /// <returns></returns>
    public async Task ChangeBookmarkIllustVisibilityAsync(bool isPrivate, params long[] bookmarkIds)
    {
        const string url = "/ajax/illusts/bookmarks/edit_restrict";
        var obj = new { bookmarkIds = bookmarkIds.Select(x => x.ToString()), bookmarkRestrict = isPrivate ? "private" : "public" };
        await CommonPostAsync<JsonNode>(url, obj);
    }



    /// <summary>
    /// 批量给收藏插画添加自定义标签
    /// </summary>
    /// <param name="bookmarkIds">收藏id</param>
    /// <param name="tags">自定义标签，添加后每个插画的标签不超过10个</param>
    /// <returns></returns>
    public async Task AddBookmarkIllustTagsAsync(IEnumerable<long> bookmarkIds, IEnumerable<string> tags)
    {
        const string url = "/ajax/illusts/bookmarks/add_tags";
        var obj = new { bookmarkIds = bookmarkIds.Select(x => x.ToString()), tags = tags };
        await CommonPostAsync<JsonNode>(url, obj);
    }


    /// <summary>
    /// 批量删除搜藏的插画
    /// </summary>
    /// <param name="bookmarkIds">收藏id</param>
    /// <returns></returns>
    public async Task DeleteBookmarkIllustsAsync(params long[] bookmarkIds)
    {
        const string url = "/ajax/illusts/bookmarks/remove";
        var obj = new { bookmarkIds = bookmarkIds.Select(x => x.ToString()) };
        await CommonPostAsync<JsonNode>(url, obj);
    }


    /// <summary>
    /// 相关推荐插画，推荐插画可能很多，将分批返回数据
    /// </summary>
    /// <param name="illustId">插画id</param>
    /// <param name="batchSize">每批返回多少个</param>
    /// <returns>可能为空</returns>
    public async IAsyncEnumerable<IEnumerable<IllustProfile>> GetRecommendIllustsAsync(int illustId, int batchSize = 20)
    {
        var initUrl = $"/ajax/illust/{illustId}/recommend/init?limit={batchSize}";
        var response = await CommonGetAsync<RecommendIllustWrapper>(initUrl);
        // 竟然有广告
        yield return response.Illusts.Where(x => x.Id != 0);
        foreach (var ids in response.NextIds.Chunk(batchSize))
        {
            var nextUrl = $"/ajax/illust/recommend/illusts?{string.Join("&", ids.Select(x => $"illust_ids[]={x}"))}";
            yield return (await CommonGetAsync<RecommendIllustWrapper>(nextUrl)).Illusts.Where(x => x.Id != 0);
        }
    }


    #endregion



    #region Novel


    /// <summary>
    /// 小说详情（包含正文）
    /// </summary>
    /// <param name="novelId">小说id</param>
    /// <returns></returns>
    public async Task<NovelInfo> GetNovelInfoAsync(int novelId)
    {
        var url = $"/ajax/novel/{novelId}";
        return await CommonGetAsync<NovelInfo>(url);
    }

    /// <summary>
    /// 小说系列（无章节信息）
    /// </summary>
    /// <param name="novelSeriesId">小说id</param>
    /// <returns></returns>
    public async Task<NovelSeries> GetNovelSeriesAsync(int novelSeriesId)
    {
        var url = $"/ajax/novel/series/{novelSeriesId}";
        return await CommonGetAsync<NovelSeries>(url);
    }

    /// <summary>
    /// 小说系列的章节信息（无正文）
    /// </summary>
    /// <param name="novelSeriesId">小说id</param>
    /// <param name="offset">章节偏移量，按章节正序</param>
    /// <param name="limit">章节数限制</param>
    /// <returns></returns>
    public async Task<List<NovelSeriesChapter>> GetNovelSeriesChaptersAsync(int novelSeriesId, int offset, int limit = 30)
    {
        var url = $"/ajax/novel/series_content/{novelSeriesId}?limit={limit}&last_order={offset}&order_by=asc";
        var wrapper = await CommonGetAsync<NovelSeriesContentWrapper>(url);
        return wrapper.SeriesContents;
    }


    /// <summary>
    /// 追更小说系列
    /// </summary>
    /// <param name="novelSeriesId">小说系列id</param>
    /// <param name="unWatch">取消追更</param>
    /// <returns></returns>
    public async Task WatchNovelSeriesAsync(int novelSeriesId, bool unWatch = false)
    {
        var url = $"/ajax/novel/series/{novelSeriesId}/{(unWatch ? "unwatch" : "watch")}";
        await CommonPostAsync<JsonNode>(url, new object());
    }


    /// <summary>
    /// 更改小说系列追更通知，追更小说系列后再开启通知
    /// </summary>
    /// <param name="novelSeriesId">小说系列id</param>
    /// <param name="enable">开启关闭通知</param>
    /// <returns></returns>
    public async Task ChangeNovelSeriesWatchListNotification(int novelSeriesId, bool enable = false)
    {
        var url = $"/ajax/novel/series/{novelSeriesId}/watchlist/notification/{(enable ? "turn_on" : "turn_off")}";
        await CommonPostAsync<JsonNode>(url, new object());
    }


    /// <summary>
    /// 小说主页内容
    /// </summary>
    /// <returns></returns>
    private async Task GetNovelHomePageAsync()
    {
        const string url = "/ajax/top/novel?mode=all";
        // todo
    }


    /// <summary>
    /// 给小说点赞，好像不能取消
    /// </summary>
    /// <param name="novelId">小说id</param>
    /// <returns></returns>
    public async Task LikeNovelAsync(int novelId)
    {
        const string url = "/ajax/novels/like";
        var obj = new { novel_id = novelId.ToString() };
        await CommonPostAsync<JsonNode>(url, obj);
    }


    /// <summary>
    /// 给小说的某一页加上书签
    /// </summary>
    /// <param name="myUserId">我的uid</param>
    /// <param name="novelId">小说id</param>
    /// <param name="page">页数，大于 0 标记，等于 0 删除标记</param>
    /// <returns></returns>
    public async Task MarkerNovelPageAsync(int myUserId, int novelId, int page)
    {
        const string url = "/novel/rpc_marker.php";
        var form = new List<KeyValuePair<string, string>>
        {
            new("mode", "save"),
            new("i_id", novelId.ToString()),
            new("u_id", myUserId.ToString()),
            new("page", page.ToString()),
        };
        var message = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Content = new FormUrlEncodedContent(form),
        };
        await _httpClient.SendAsync(message);
    }


    /// <summary>
    /// 收藏小说，返回收藏id
    /// </summary>
    /// <param name="novelId">小说id</param>
    /// <param name="isPrivate">不公开</param>
    /// <param name="comment">收藏时附加的评论</param>
    /// <param name="tags">收藏时添加的标签，最多10个（小说标签没有翻译）</param>
    /// <returns>收藏id</returns>
    public async Task<long> AddBookmarkNovelAsync(int novelId, bool isPrivate = false, string comment = "", params string[] tags)
    {
        var request = new AddBookmarkNovelRequest
        {
            NovelId = novelId,
            IsPrivate = isPrivate,
            Comment = comment,
            Tags = tags.Take(10),
        };
        return await AddBookmarkNovelAsync(request);
    }


    /// <summary>
    /// 收藏小说，返回收藏id
    /// </summary>
    /// <param name="request">收藏请求</param>
    /// <returns>收藏id</returns>
    public async Task<long> AddBookmarkNovelAsync(AddBookmarkNovelRequest request)
    {
        const string url = "/ajax/novels/bookmarks/add";
        var result = await CommonPostAsync<string>(url, request);
        long.TryParse(result, out var bookmarkId);
        return bookmarkId;
    }


    /// <summary>
    /// 删除收藏的小说
    /// </summary>
    /// <param name="bookmarkId">小说id</param>
    /// <returns></returns>
    public async Task DeleteBookmarkNovelAsync(int bookmarkId)
    {
        const string url = "/ajax/novels/bookmarks/delete";
        var form = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("del", "1"),
            new KeyValuePair<string, string>("book_id", bookmarkId.ToString())
        };
        var message = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Content = new FormUrlEncodedContent(form),
        };
        await CommonSendAsync<JsonNode>(message);
    }


    /// <summary>
    /// 批量更改收藏小说的公开属性
    /// </summary>
    /// <param name="isPrivate">不公开</param>
    /// <param name="bookmarkIds">收藏id</param>
    /// <returns></returns>
    public async Task ChangeBookmarkNovelVisibilityAsync(bool isPrivate, params long[] bookmarkIds)
    {
        const string url = "/ajax/novels/bookmarks/edit_restrict";
        var obj = new { bookmarkIds = bookmarkIds.Select(x => x.ToString()), bookmarkRestrict = isPrivate ? "private" : "public" };
        await CommonPostAsync<JsonNode>(url, obj);
    }


    /// <summary>
    /// 批量给收藏的小说添加自定义标签
    /// </summary>
    /// <param name="bookmarkIds">小说id</param>
    /// <param name="tags">自定义标签，添加后每个小说的标签不超过10个</param>
    /// <returns></returns>
    public async Task AddBookmarkNovelTagsAsync(IEnumerable<long> bookmarkIds, IEnumerable<string> tags)
    {
        const string url = "/ajax/novels/bookmarks/add_tags";
        var obj = new { bookmarkIds = bookmarkIds.Select(x => x.ToString()), tags = tags.Take(10) };
        await CommonPostAsync<JsonNode>(url, obj);
    }


    /// <summary>
    /// 删除收藏的小说
    /// </summary>
    /// <param name="bookmarkIds">小说id</param>
    /// <returns></returns>
    public async Task DeleteBookmarkNovelsAsync(params long[] bookmarkIds)
    {
        const string url = "/ajax/novels/bookmarks/remove";
        var obj = new { bookmarkIds = bookmarkIds.Select(x => x.ToString()) };
        await CommonPostAsync<JsonNode>(url, obj);
    }


    /// <summary>
    /// 相关推荐小说，推荐的小说可能很多，将分批返回数据
    /// </summary>
    /// <param name="novelId">小说id</param>
    /// <param name="batchSize">每批返回多少个</param>
    /// <returns>可能为空</returns>
    public async IAsyncEnumerable<IEnumerable<NovelProfile>> GetRecommendNovelsAsync(int novelId, int batchSize = 10)
    {
        var initUrl = $"/ajax/novel/{novelId}/recommend/init?limit={batchSize}";
        var response = await CommonGetAsync<RecommendNovelWrapper>(initUrl);
        // 竟然有广告
        yield return response.Novels.Where(x => x.Id != 0);
        foreach (var ids in response.NextIds.Chunk(batchSize))
        {
            var nextUrl = $"/ajax/novel/recommend/novels?{string.Join("&", ids.Select(x => $"novelIds[]={x}"))}";
            yield return (await CommonGetAsync<RecommendNovelWrapper>(nextUrl)).Novels.Where(x => x.Id != 0);
        }
    }



    #endregion



    #region Bookmark


    /// <summary>
    /// 用户已收藏的插画数量
    /// </summary>
    /// <param name="userId">用户uid</param>
    /// <param name="isPrivate">不公开</param>
    /// <returns></returns>
    public async Task<int> GetUserBookmarkIllustCountAsync(int userId, bool isPrivate = false)
    {
        var url = $"/ajax/user/{userId}/illusts/bookmarks?tag=&offset=0&limit=1&rest={(isPrivate ? "hide" : "show")}";
        var wrapper = await CommonGetAsync<BookmarkIllustWrapper>(url);
        return wrapper.Total;
    }



    /// <summary>
    /// 收藏的插画
    /// </summary>
    /// <param name="userId">用户uid</param>
    /// <param name="offset">偏移量</param>
    /// <param name="limit">返回数量，返回数可能小于此数</param>
    /// <param name="isPrivate">不公开</param>
    /// <param name="tag">过滤标签</param>
    /// <returns></returns>
    public async Task<List<IllustProfile>> GetUserBookmarkIllustsAsync(int userId, int offset, int limit = 48, bool isPrivate = false, string? tag = null)
    {
        limit = Math.Clamp(limit, 1, 100);
        if (!string.IsNullOrWhiteSpace(tag))
        {
            tag = Uri.EscapeDataString(tag);
        }
        var url = $"/ajax/user/{userId}/illusts/bookmarks?tag={tag}&offset={offset}&limit={limit}&rest={(isPrivate ? "hide" : "show")}";
        var wrapper = await CommonGetAsync<BookmarkIllustWrapper>(url);
        return wrapper.Works;
    }


    /// <summary>
    /// 已收藏插画的所有自定义标签，包括公开和非公开，标签数过多则不会返回全部内容
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <returns></returns>
    public async Task<UserBookmarkTag> GetUserBookmarkIllustTagsAsync(int userId)
    {
        var url = $"/ajax/user/{userId}/illusts/bookmark/tags?lang=zh";
        return await CommonGetAsync<UserBookmarkTag>(url);
    }


    /// <summary>
    /// 收藏的小说数量
    /// </summary>
    /// <param name="userId">用户uid</param>
    /// <param name="isPrivate">不公开</param>
    /// <returns></returns>
    public async Task<int> GetUserBookmarkNovelCountAsync(int userId, bool isPrivate = false)
    {
        var url = $"/ajax/user/{userId}/novels/bookmarks?tag=&offset=0&limit=1&rest={(isPrivate ? "hide" : "show")}";
        var wrapper = await CommonGetAsync<BookmarkNovelWrapper>(url);
        return wrapper.Total;
    }


    /// <summary>
    /// 收藏的小说
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <param name="offset">偏移量</param>
    /// <param name="limit">返回数量，返回数可能小于此数</param>
    /// <param name="isPrivate">不公开</param>
    /// <param name="tag">过滤标签</param>
    /// <returns></returns>
    public async Task<List<NovelProfile>> GetUserBookmarkNovelsAsync(int userId, int offset, int limit = 24, string? tag = null, bool isPrivate = false)
    {
        limit = Math.Clamp(limit, 1, 100);
        if (!string.IsNullOrWhiteSpace(tag))
        {
            tag = Uri.EscapeDataString(tag);
        }
        var url = $"/ajax/user/{userId}/novels/bookmarks?tag={tag}&offset={offset}&limit={limit}&rest={(isPrivate ? "hide" : "show")}";
        var wrapper = await CommonGetAsync<BookmarkNovelWrapper>(url);
        return wrapper.Works;
    }


    /// <summary>
    /// 已收藏插画的所有自定义标签，包括公开和非公开，标签数过多则不会返回全部内容
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <returns></returns>
    public async Task<UserBookmarkTag> GetUserBookmarkNovelTagsAsync(int userId)
    {
        var url = $"/ajax/user/{userId}/novels/bookmark/tags";
        return await CommonGetAsync<UserBookmarkTag>(url);
    }


    #endregion



    #region Following


    /// <summary>
    /// 已关注用户的数量
    /// </summary>
    /// <param name="userId">用户uid</param>
    /// <param name="isPrivate">不公开</param>
    /// <returns></returns>
    public async Task<int> GetFollowingUserCountAsync(int userId, bool isPrivate = false)
    {
        var url = $"/ajax/user/{userId}/following?offset=0&limit=1&rest={(isPrivate ? "hide" : "show")}";
        var wrapper = await CommonGetAsync<FollowingUserWrapper>(url);
        return wrapper.Total;
    }



    /// <summary>
    /// 已关注的用户
    /// </summary>
    /// <param name="userId">用户uid</param>
    /// <param name="offset">偏移量</param>
    /// <param name="limit">返回数据量</param>
    /// <param name="isPrivate">不公开</param>
    /// <returns></returns>
    public async Task<List<FollowingUser>> GetFollowingUsersAsync(int userId, int offset, int limit = 100, bool isPrivate = false)
    {
        limit = Math.Clamp(limit, 0, 100);
        var url = $"/ajax/user/{userId}/following?offset={offset}&limit={limit}&rest={(isPrivate ? "hide" : "show")}";
        var wrapper = await CommonGetAsync<FollowingUserWrapper>(url);
        return wrapper.Users;
    }

    /// <summary>
    /// 已关注用户的最新插画漫画作品
    /// </summary>
    /// <param name="page">第几页，最多35页，35页后的内容和35页相同</param>
    /// <param name="onlyR18">仅显示r18作品</param>
    /// <returns></returns>
    public async Task<List<IllustProfile>> GetFollowingUserLatestIllustsAsync(int page, bool onlyR18 = false)
    {
        var url = $"/ajax/follow_latest/illust?p={page}&mode={(onlyR18 ? "r18" : "all")}";
        var wrapper = await CommonGetAsync<FollowingLatestWorkWrapper>(url);
        return wrapper.Thumbnails.Illusts;
    }

    /// <summary>
    /// 已关注用户的最新小说作品
    /// </summary>
    /// <param name="page">第几页，最多35页，35页后的内容和35页相同</param>
    /// <param name="onlyR18">仅显示r18作品</param>
    /// <returns></returns>
    public async Task<List<NovelProfile>> GetFollowingUserLatestNovelsAsync(int page, bool onlyR18 = false)
    {
        var url = $"/ajax/follow_latest/novel?p={page}&mode={(onlyR18 ? "r18" : "all")}";
        var wrapper = await CommonGetAsync<FollowingLatestWorkWrapper>(url);
        return wrapper.Thumbnails.Novels;
    }


    /// <summary>
    /// 添加关注用户
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <param name="isPrivate">不公开</param>
    /// <returns></returns>
    public async Task AddFollowingUserAsync(int userId, bool isPrivate = false)
    {
        const string url = "/bookmark_add.php";
        var form = new List<KeyValuePair<string, string>>
        {
            new("mode", "add"),
            new("type", "user"),
            new("user_id", userId.ToString()),
            new("tag", ""),
            new("restrict", isPrivate ? "1" : "0"),
            new("format", "json"),
        };
        var message = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Content = new FormUrlEncodedContent(form),
        };
        await _httpClient.SendAsync(message);
    }


    /// <summary>
    /// 删除关注用户
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <returns></returns>
    public async Task DeleteFollowingUserAsync(int userId)
    {
        const string url = "/rpc_group_setting.php";
        var form = new List<KeyValuePair<string, string>>
        {
            new("mode", "del"),
            new("type", "bookuser"),
            new("id", userId.ToString()),
        };
        var message = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Content = new FormUrlEncodedContent(form),
        };
        await _httpClient.SendAsync(message);
    }


    /// <summary>
    /// 更改已关注用户的公开属性
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <param name="isPrivate">不公开</param>
    /// <returns></returns>
    public async Task ChangeFollowingUserVisibilityAsync(int userId, bool isPrivate)
    {
        const string url = "/rpc/index.php";
        var form = new List<KeyValuePair<string, string>>
        {
            new("mode", "following_user_restrict_change"),
            new("user_id", userId.ToString()),
            new("restrict", isPrivate ? "1" : "0"),
        };
        var message = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Content = new FormUrlEncodedContent(form),
        };
        await _httpClient.SendAsync(message);
    }


    /// <summary>
    /// 新关注用户后推荐的相关用户
    /// </summary>
    /// <param name="userId">关注的用户id</param>
    /// <param name="userNumber">推荐的用户数量</param>
    /// <param name="workNumber">每个用户展示的作品数</param>
    /// <param name="allowR18">允许展示r18作品（存疑）</param>
    /// <returns></returns>
    public async Task<List<RecommendUser>> GetRecommendAfterFollowingUserAsync(int userId, int userNumber = 20, int workNumber = 3, bool allowR18 = true)
    {
        var url = $"/ajax/user/{userId}/recommends?userNum={userNumber}&workNum={workNumber}&isR18={allowR18}";
        var response = await CommonGetAsync<RecommendUserResponse>(url);
        var dic_illust = response.Thumbnails.Illusts.ToDictionary(x => x.Id);
        var dic_novel = response.Thumbnails.Novels.ToDictionary(x => x.Id);
        var dic_map = response.RecommendMaps.ToDictionary(x => x.UserId);
        foreach (var user in response.Users)
        {
            var illusts = new List<IllustProfile>(workNumber);
            var novels = new List<NovelProfile>(workNumber);
            if (dic_map.TryGetValue(user.UserId, out var map))
            {
                foreach (var illust_id_str in map.IllustIds)
                {
                    if (int.TryParse(illust_id_str, out var illustId))
                    {
                        if (dic_illust.TryGetValue(illustId, out var illust))
                        {
                            illusts.Add(illust);
                        }
                    }
                }
                foreach (var novel_id_str in map.NovelIds)
                {
                    if (int.TryParse(novel_id_str, out var novelId))
                    {
                        if (dic_novel.TryGetValue(novelId, out var novel))
                        {
                            novels.Add(novel);
                        }
                    }
                }
            }
            user.Illusts = illusts;
            user.Novels = novels;
        }
        return response.Users;
    }


    #endregion




    #region Search



    /// <summary>
    /// 搜索推荐
    /// </summary>
    /// <returns></returns>
    private async Task GetSearchSuggestionAsync()
    {
        const string url = "/ajax/search/suggestion?mode=all";
        // todo
    }


    /// <summary>
    /// 修改喜欢的标签
    /// </summary>
    /// <param name="tags">所有标签</param>
    /// <returns></returns>
    public async Task ChangeFavorateTags(IEnumerable<string> tags)
    {
        const string url = "/ajax/favorite_tags/save";
        await CommonPostAsync<JsonNode>(url, new { tags });
    }



    /// <summary>
    /// 搜索候选词
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    public async Task<List<SearchCandidate>> GetSearchCandidatesAsync(string keyword)
    {
        var url = $"/rpc/cps.php?keyword={keyword}";
        var node = await CommonGetAsync<JsonNode>(url);
        if (node["candidates"] is JsonArray array)
        {
            var list = JsonSerializer.Deserialize<List<SearchCandidate>>(array);
            if (list?.Any() ?? false)
            {
                return list;
            }
        }
        return new List<SearchCandidate>();
    }



    private async Task SearchAsync(string keyword)
    {
        // order: 最新 date_d，最旧 date
        // mode: all, safe, r18
        // p: 1,2,3 页数
        // s_mode: 标签部分一致 s_tag，标签一致 s_all，标题说明文字：s_tc
        // type: 全部 all，插画动图 illust_and_ugoira，插画 illust，漫画 manga，动图 ugoira
        // wlt 图宽大于，wgl 图宽小于，hgt，hlt
        // ratio: 宽高比，横图 0.5，纵图 -0.5，正方形 0
        // tool: 制图工具
        // scd，ecd：起止时间  scd=2022-12-22&ecd=2022-12-29
        var url = $"/ajax/search/artworks/{keyword}?word={keyword}&order=date_d&mode=safe&p=1&s_mode=s_tag&type=all";
        url = $"/ajax/search/illustrations/{keyword}?word={keyword}&order=date&mode=r18&scd=2022-12-22&p=1&s_mode=s_tc&type=illust_and_ugoira&wlt=3000&hlt=3000&ratio=0.5&tool=SAI";
        url = $"/ajax/search/manga/a?word=a&order=date_d&mode=all&scd=2022-12-22&ecd=2022-12-29&p=1&s_mode=s_tag&type=manga&ratio=0&lang=zh";
        url = "/ajax/search/novels/a?word=a&order=date_d&mode=all&scd=2022-12-22&ecd=2022-12-29&p=1&s_mode=s_tag&gs=0&lang=zh";

        // tlt 字数大于，tgt 字数小于
        // original_only=1 仅原创
        // work_lang=zh-cn 作品语言
        url = "/ajax/search/novels/a?word=a&order=date_d&mode=all&scd=2022-12-22&ecd=2022-12-29&p=1&s_mode=s_tag&tlt=5000&tgt=19999&original_only=1&work_lang=zh-cn&gs=0&lang=zh";
    }




    #endregion







}

