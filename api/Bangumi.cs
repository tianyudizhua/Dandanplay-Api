using static DandanplayApi.Common;

namespace DandanplayApi
{
    class Bangumi
    {
        public static string Shin()
        {
            string url = $"https://api.acplay.net/api/v2/bangumi/shin?filterAdultContent={FilterAdultContent}";
            return GetContent(url);
        }

        public static string Season()
        {
            string url = "https://api.acplay.net/api/v2/bangumi/season/anime";
            return GetContent(url);
        }

        public static string SeasonAnime(string year, string month)
        {
            string url = $"https://api.acplay.net/api/v2/bangumi/season/anime/{year}/{month}?filterAdultContent={FilterAdultContent}";
            return GetContent(url);
        }

        public static string QueueIntro()
        {
            string url = "https://api.acplay.net/api/v2/bangumi/queue/intro";
            return GetContent(url);
        }

        public static string QueueDetails()
        {
            string url = "https://api.acplay.net/api/v2/bangumi/queue/details";
            return GetContent(url);
        }

        public static string AnimeDetails(string animeId)
        {
            string url = $"https://api.acplay.net/api/v2/bangumi/{animeId}";
            return GetContent(url);
        }
    }
}