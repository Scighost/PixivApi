![Nuget](https://img.shields.io/nuget/v/Scighost.PixivApi)
![Nuget](https://img.shields.io/nuget/dt/Scighost.PixivApi)

# Pixiv Api

0.x 版本期间不保证 API 的可用性和稳定性，方法签名随时有可能更改。

## 现有功能

- 插画、漫画、小说
  - 详细信息
  - 点赞收藏
  - 添加追更
  - 修改标签
  - 相关推荐
- 用户
  - 关注取关
  - 全部作品
  - 最近作品
  - 收藏作品
  - 相关推荐
- ……

## 开始使用

Pixiv 的登录过程使用了 Cloudflare 保护，基本无法绕过，部分需要账号的功能请在浏览器上登录后使用包含 cookie 和 ua 的构造函数。

Pixiv 的图片使用了防盗链保护，下载图片时需要添加 `Referer` : `https://www.pixiv.net/`

> PixivClient 是所有 Api 的请求类，下面列出部分 Api，更多内容请在使用中探索或查看源码

### 构造 Client

``` cs
using Scighost.PixivApi;

// 绕过 SNI，大陆直连
PixivClient client = new PixivClient(bypassSNI: true);

// 自定义直连 IP，默认使用 Pixivision 的 IP
client = new PixivClient(bypassSNI: true, ip: "123.456.789.100");

// 设置 HTTP 代理
client = new PixivClient(httpProxy: "127.0.0.1:1080");

// 使用账号，可与直连或代理结合
client = new PixivClient(cookie: "your cookie", userAgent: "your ua");

// 在进行关注、收藏等非 GET 操作前需要调用此方法获取 token，返回为 true 代表获取成功，建议构造完成后立即调用。
Debug.Assert(await client.GetTokenAsync());
```

### 插画 & 漫画

``` CSharp
// 插画漫画详细信息
IllustInfo _ = await client.GetIllustInfoAsync(illustId: 12345678);

// 插画图片
List<IllustImage> _ = await client.GetIllustPagesAsync(illustId: 12345678);

// 动图元数据
AnimateIllustMeta _ = await client.GetAnimateIllustMetaAsync(illustId: 12345678);

// 追更漫画
await client.WatchMangaSeriesAsync(mangaSeriesId: 123456, unWatch: false);

// 更改追更通知状态
await client.ChangeMangaSeriesWatchListNotification(mangaSeriesId: 123456, enable: true);

// 相关推荐，推荐很多但不可能一次全部获取，所以使用异步流
await foreach (IEnumerable<IllustProfile> illusts in client.GetRecommendIllustsAsync(illustId: 12345678, batchSize: 20))
{
    Debug.Assert(illusts.Count() == 20);
}
```

### 小说

``` CSharp
// 小说系列 & 系列章节
NovelSeries _ = await client.GetNovelSeriesAsync(novelSeriesId: 123456);
List<NovelSeriesChapter> _ = await client.GetNovelSeriesChaptersAsync(novelSeriesId: 123456, offset: 0, limit: 10);

// 加书签
await client.MarkerNovelPageAsync(myUserId: 1234567, novelId: 12345678, page: 1);

// 收藏小说
long bookmarkId = await client.AddBookmarkNovelAsync(novelId: 12345678, isPrivate: false, comment: "评论", tags: "自定义标签");

// 批量更改收藏公开属性
await client.ChangeBookmarkNovelVisibilityAsync(isPrivate: true, bookmarkIds: new long[] { 1, 2 });

// 批量增加自定义标签
await client.AddBookmarkNovelTagsAsync(bookmarkIds: new long[] { 1, 2, 3 }, tags: new string[] { "标签1", "标签2" });
```

### 用户 & 收藏

``` CSharp
// 我的 Uid
int myUid = await client.GetMyUserIdAsync();

// 已关注的用户
List<FollowingUser> _ = await client.GetFollowingUsersAsync(userId: 123456, offset: 0, limit: 20, isPrivate: false);

// 已关注用户的最新插画漫画作品
List<IllustProfile> _ = await client.GetFollowingUserLatestIllustsAsync(page: 2, onlyR18: false);

// 关注新用户后的相关推荐
List<RecommendUser> _ = await client.GetRecommendAfterFollowingUserAsync(userId: 123456, userNumber: 20, workNumber: 3, allowR18: true);

// 已收藏的插画数量
int count = await client.GetUserBookmarkIllustCountAsync(userId: 123456, isPrivate: false);

// 已收藏插画的所有自定义标签
UserBookmarkTag _ = await client.GetUserBookmarkIllustTagsAsync(userId: 123456);
```

## PR 规范

- 在新分支上提交代码
- 专注于一个功能或修复
- 允许编辑

