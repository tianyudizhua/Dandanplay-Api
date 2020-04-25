using static DandanplayApi.Common;

namespace DandanplayApi
{
    class PlayHistory
    {
        public static string GetPlayHistory(string fromDate, string toDate)
        {
            string url = $"https://api.acplay.net/api/v2/playhistory?fromDate={fromDate}&toDate={toDate}";
            return GetContent(url);
        }

        public static string AddPlayHistory(int episodeId, bool addToFavorite, int rating)
        {
            string url = "https://api.acplay.net/api/v2/playhistory";
            string postData = $"{{\"episodeIdList\":[{episodeId}],\"addToFavorite\":{addToFavorite},\"rating\":{rating}}}";
            return PostContent(url, postData);
        }

        public static string AddPlayHistory(int[] episodeIdList)
        {
            string url = "https://api.acplay.net/api/v2/playhistory";
            string episodeId="";
            foreach (var item in episodeIdList)
            {
                episodeId += item + ",";
            }
            episodeId = episodeId[0..^1];
            string postData = $"{{\"episodeIdList\":[{episodeId}]}}";
            return PostContent(url, postData);
        }
    }
}