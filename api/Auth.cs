using System;
using System.IO;
using System.Net;
using System.Text;
using static DandanplayApi.Common;

namespace DandanplayApi
{
    class Auth
    {
        public static string Login()
        {
            string url = "https://api.acplay.net/api/v2/login";
            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string plaintext = AppId + Password + unixTimestamp + UserName + Appsecret;
            string md5 = GetMd5Hash(plaintext);
            string postData = $"{{\"userName\":\"{UserName}\",\"password\":\"{Password}\",\"appId\":\"{AppId}\",\"unixTimestamp\":{unixTimestamp},\"hash\":\"{md5}\"}}";
            return PostContent(url, postData);
        }

        public static string Renew()
        {
            string url = "https://api.acplay.net/api/v2/login/renew";
            return GetContent(url);
        }

        public static string AppLogin(string source, string accessToken)
        {
            string url = "https://api.acplay.net/api/v2/applogin";
            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string plaintext = accessToken + AppId + source + unixTimestamp + UserId + Appsecret;
            string md5 = GetMd5Hash(plaintext);
            string postData = $"{{\"source\":\"{source}\",\"userId\":\"{UserId}\",\"accessToken\":\"{accessToken}\",\"appId\":\"{AppId}\",\"unixTimestamp\":{unixTimestamp},\"hash\":\"{md5}\"}}";
            return PostContent(url, postData);
        }

        public static string Register()
        {
            string url = "https://api.acplay.net/api/v2/register";
            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string plaintext = AppId + Email + Password + ScreenName + unixTimestamp + UserName + Appsecret;
            string md5 = GetMd5Hash(plaintext);
            string postData = $"{{\"appId\":\"{AppId}\",\"userName\":\"{UserName}\",\"password\":\"{Password}\",\"email\":\"{Email}\",\"screenName\":\"{ScreenName}\",\"unixTimestamp\":{unixTimestamp},\"hash\":\"{md5}\"}}";
            return PostContent(url, postData);
        }

        public static string ChangePassword(string oldPassword, string newPassword)
        {
            string url = "https://api.acplay.net/api/v2/Password";
            string postData = $"{{\"oldPassword\":\"{oldPassword}\",\"newPassword\":\"{newPassword}\"}}";
            return PostContent(url, postData);
        }
        
        //! 未完成
        //todo 修改用户资料
        public static string ChangeProfile() { return "0"; }

        public static string ResetPassword()
        {
            string url = "https://api.acplay.net/api/v2/resetPassword";
            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string plaintext = AppId + Email + unixTimestamp + UserName + Appsecret;
            string md5 = GetMd5Hash(plaintext);
            string postData = $"{{\"appId\":\"{AppId}\",\"userName\":\"{UserName}\",\"email\":\"{Email}\",\"unixTimestamp\":{unixTimestamp},\"hash\":\"{md5}\"}}";
            return PostContent(url, postData);
        }

        public static string FindMyId()
        {
            string url = "https://api.acplay.net/api/v2/resetPassword";
            int unixTimestamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string plaintext = AppId + Email + unixTimestamp + Appsecret;
            string md5 = GetMd5Hash(plaintext);
            string postData = $"{{\"appId\":\"{AppId}\",\"email\":\"{Email}\",\"unixTimestamp\":{unixTimestamp},\"hash\":\"{md5}\"}}";
            return PostContent(url, postData);
        }
    }
}