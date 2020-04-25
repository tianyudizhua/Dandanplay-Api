using static DandanplayApi.Common;

namespace DandanplayApi
{
    class Homepage
    {
        public static string GetHomepage()
        {
            string url = $"https://api.acplay.net/api/v2/homepage?filterAdultContent={FilterAdultContent}";
            return GetContent(url);
        }

        public static string Banner()
        {
            string url = $"https://api.acplay.net/api/v2/homepage/banner";
            return GetContent(url);
        }

        public static string PopularTorrents()
        {
            string url = $"https://api.acplay.net/api/v2/homepage/populartorrents";
            return GetContent(url);
        }
    }
}