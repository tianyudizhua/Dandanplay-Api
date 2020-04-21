using System;

namespace DandanplayApi
{
    class Auth
    {
        public static string Login(string userName, string password, string appId, string appSecret, string dataFormat = "json")
        {
            string url = "https://api.acplay.net/api/v2/login";
            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string plaintext = appId + password + unixTimestamp + userName + appSecret;
            string md5 = Common.GetMd5Hash(plaintext);
            string postData = $"{{\"usrName\":\"{userName}\",\"password\":\"{password}\",\"appId\":\"{appId}\",\"unixTimestamp\":{unixTimestamp},\"hash\":\"{md5}\"}}";
            return Common.GetContent(url, postData, dataFormat);
        }

        public static string Renew(string token, string dataFormat = "json")
        {
            string url = "https://api.acplay.net/api/v2/login/renew";
            var request = WebRequest.Create(url);
            request.Headers.Add("Accept: application/" + dataFormat);
            request.Headers.Add($"\"Authorization\":\"{token}\"");
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream, Encoding.UTF8);
            var html = streamReader.ReadToEnd();
            response.Close();
            return html;
        }
        public static string AppLogin(string source, string userId, string accessToken, string appId, string appSecret, string dataFormat = "json")
        {
            string url = "https://api.acplay.net/api/v2/applogin";
            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string plaintext = accessToken + appId + source + unixTimestamp + userId + appSecret;
            string md5 = Common.GetMd5Hash(plaintext);
            string postData = $"{{\"source\":\"{source}\",\"userId\":\"{userId}\",\"accessToken\":\"{accessToken}\",\"appId\":\"{appId}\",\"unixTimestamp\":{unixTimestamp},\"hash\":\"{md5}\"}}";
            return Common.GetContent(url, postData, dataFormat);
        }
    }
}