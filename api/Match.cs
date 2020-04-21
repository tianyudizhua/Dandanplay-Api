using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace DandanplayApi
{
    public class Match
    {
        public static string GetMatch(string filePath, string dataFormat = "json")
        {
            string url = "https://api.acplay.net/api/v2/match";
            var fileInfo = new FileInfo(filePath);
            var fileName = fileInfo.Name.Replace(fileInfo.Extension, "");
            var fileSize = fileInfo.Length;
            var fileStream = new FileStream(filePath, FileMode.Open);
            string md5 = Common.GetMd5Hash(fileStream, 16 * 1024 * 1024);
            string postData = $"{{\"fileName\":\"{fileName}\",\"fileHash\":\"{md5}\",\"fileSize\":{fileSize}}}";
            return Common.GetContent(url, postData, dataFormat);
        }

        public static string SendMatch(long episodeId, string filePath, string dataFormat = "json")
        {
            string url = "https://api.acplay.net/api/v2/match/" + episodeId;
            string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1, filePath.LastIndexOf('.'));
            var fileStream = new FileStream(filePath, FileMode.Open);
            string md5 = Common.GetMd5Hash(fileStream);
            string postData = $"{{\"episodeId\":\"{episodeId}\",\"hash\":\"{md5}\",\"fileName\":\"{fileName}\"}}";
            return Common.GetContent(url, postData, dataFormat);
        }

        public static string GetContent(string url, string postData, string dataFormat = "json")
        {
            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("Content-Type: application/json");
            request.Headers.Add("Accept: application/" + dataFormat);
            byte[] postArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = postArray.Length;
            var dataStream = request.GetRequestStream();
            dataStream.Write(postArray, 0, postArray.Length);
            dataStream.Close();
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream, Encoding.UTF8);
            var html = streamReader.ReadToEnd();
            response.Close();
            return html;
        }
    }
}
