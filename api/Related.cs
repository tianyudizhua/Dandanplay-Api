using static DandanplayApi.Common;

namespace DandanplayApi
{
    class Related
    {
        public static string OpposeRelation(long episodeId, string sourceUrl)
        {
            string url = $"https://api.acplay.net/api/v2/related/{episodeId}?url={sourceUrl}";
            return GetContent(url);
        }

        public static string GetRelation(long episodeId)
        {
            string url = $"https://api.acplay.net/api/v2/related/{episodeId}";
            return GetContent(url);
        }

        public static string AddRelation(long episodeId, string sourceUrl, double shift)
        {
            string url = $"https://api.acplay.net/api/v2/related/{episodeId}";
            string postData = $"{{\"episodeId\":{episodeId},\"url\":\"{sourceUrl}\",\"shift\":{shift}}}";
            return PostContent(url,postData);
        }
    }
}