using static DandanplayApi.Common;

namespace DandanplayApi
{
    class Favorite
    {
        public static string GetFavorite()
        {
            string url = "https://api.acplay.net/api/v2/favorite";
            return GetContent(url);
        }

        public static string GetFavorite(bool onlyOnAir)
        {
            string url = $"https://api.acplay.net/api/v2/favorite?onlyOnAir={onlyOnAir}";
            return GetContent(url);
        }

        public static string AddFavorite(string animeId, string favoriteStatus, int rating, string comment)
        {
            string url = "https://api.acplay.net/api/v2/favorite";
            string postData = $"{{\"animeId\":\"{animeId}\",\"favoriteStatus\":\"{favoriteStatus}\",\"rating\":{rating},\"comment\":\"{comment}\"}}";
            return PostContent(url, postData);
        }

        public static string DeleteFavorite(string animeId)
        {
            string url = $"https://api.acplay.net/api/v2/favorite/{animeId}";
            return GetContent(url);
        }
    }
}