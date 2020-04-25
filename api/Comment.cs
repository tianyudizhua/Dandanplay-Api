using static DandanplayApi.Common;

namespace DandanplayApi
{
    class Comment
    {
        public static string GetComment(long episodeId, long from = 0, bool withRelated = false)
        {
            string url = $"https://api.acplay.net/api/v2/comment/{episodeId}?from={from}&withRelated={withRelated}";
            return GetContent(url);
        }

        public static string SendComment(long episodeId, int time, int mode, int color, string comment)
        {
            string url = $"https://api.acplay.net/api/v2/comment/{episodeId}";
            string postData = $"{{\"time\":{time},\"mode\":{mode},\"color\":{color},\"comment\":\"{comment}\"}}";
            return PostContent(url, postData);
        }

        public static string ExtComment(string url)
        {
            url = "https://api.acplay.net/api/v2/extcomment?url=" + System.Net.WebUtility.HtmlEncode(url);
            return GetContent(url);
        }
    }
}