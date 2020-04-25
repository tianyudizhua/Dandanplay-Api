using static DandanplayApi.Common;

namespace DandanplayApi
{
    class Search
    {
        public static string Anime(string keyword)
        {
            string url = $"https://api.acplay.net/api/v2/search/anime?keyword={keyword}";
            return GetContent(url);
        }

        public static string Anime(string keyword, string type)
        {
            string url = $"https://api.acplay.net/api/v2/search/anime?keyword={keyword}&type={type}";
            return GetContent(url);
        }

        public static string Episodes(string anime)
        {
            string url = $"https://api.acplay.net/api/v2/search/episodes?anime={anime}";
            return GetContent(url);
        }

        public static string Episodes(string anime, string episode)
        {
            string url = $"https://api.acplay.net/api/v2/search/episodes?anime={anime}&episode={episode}";
            return GetContent(url);
        }

        public static string Tag(string tags)
        {
            string url = $"https://api.acplay.net/api/v2/search/tag?tags={tags}";
            return GetContent(url);
        }

        public static string AdvConfig()
        {
            string url = $"https://api.acplay.net/api/v2/search/adv/config";
            return GetContent(url);
        }

        //! 未完成
        //todo 高级搜索
        public static string Adv() { return "0"; }
    }
}