using System.IO;
using System.Net;
using System.Text;
using static DandanplayApi.Common;

namespace DandanplayApi
{
    public class Match
    {
        public static string GetMatch(string filePath)
        {
            string url = "https://api.acplay.net/api/v2/match";
            var fileInfo = new FileInfo(filePath);
            var fileName = fileInfo.Name.Replace(fileInfo.Extension, "");
            var fileSize = fileInfo.Length;
            var fileStream = new FileStream(filePath, FileMode.Open);
            string md5 = GetMd5Hash(fileStream, 16 * 1024 * 1024);
            string postData = $"{{\"fileName\":\"{fileName}\",\"fileHash\":\"{md5}\",\"fileSize\":{fileSize}}}";
            return PostContent(url, postData);
        }

        public static string SendMatch(long episodeId, string filePath)
        {
            string url = "https://api.acplay.net/api/v2/match/" + episodeId;
            string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1, filePath.LastIndexOf('.'));
            var fileStream = new FileStream(filePath, FileMode.Open);
            string md5 = GetMd5Hash(fileStream);
            string postData = $"{{\"episodeId\":\"{episodeId}\",\"hash\":\"{md5}\",\"fileName\":\"{fileName}\"}}";
            return PostContent(url, postData);
        }
    }
}
