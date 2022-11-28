using System;
using System.Collections.Generic;
using System.Text;

namespace Scighost.PixivApi.Illust
{
    public enum RankType
    {
        Daily,
        Weekly,
        Monthly,
        Rookie,
        Original,
        Daily_ai,
        Male,
        Female
    }

    public class IllustRankItem
    {
        public int Rank { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public int ViewCount { get; set; }
        public int RatingCount { get; set; }
        public int ID { get; set; }
    }
}
