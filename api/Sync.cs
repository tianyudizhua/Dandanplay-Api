using static DandanplayApi.Common;

namespace DandanplayApi
{
    class Sync
    {
        public static string DeleteRule(string ruleId)
        {
            string url = $"https://api.acplay.net/api/v2/sync/autodownload/{ruleId}";
            return GetContent(url);
        }

        public static string GetRule(string ruleId)
        {
            string url = $"https://api.acplay.net/api/v2/sync/autodownload/{ruleId}";
            return GetContent(url);
        }

        //! 未完成
        //todo 增加或更新自动下载规则
        public static string AddRule(string ruleId)
        {
            // string url = $"https://api.acplay.net/api/v2/sync/autodownload/{ruleId}";
            // string postData = "";
            // return PostContent(url, postData);
            return "0";
        }

        public static string AllRules(string[] ruleIdsList)
        {
            string url = "https://api.acplay.net/api/v2/sync/autodownload";
            string ruleIds = "";
            foreach (var item in ruleIdsList)
            {
                ruleIds += $"\"{item}\",";
            }
            ruleIds = ruleIds[0..^1];
            string postData = $"{{\"currentRuleIds\":[{ruleIds}]}}";
            return PostContent(url, postData);
        }
    }
}