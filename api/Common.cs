using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace DandanplayApi
{
    class Common
    {
        public static string AppId { get; set; }
        public static string Appsecret { get; set; }
        public static string DataFormat { get; set; }
        public static string Token { get; set; }
        public static string UserId { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string Email { get; set; }
        public static string ScreenName { get; set; }
        public static bool FilterAdultContent { get; set; }

        public static string PostContent(string url, string postData)
        {
            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.Headers.Add("Content-Type: application/json");
            request.Headers.Add("Accept: application/" + DataFormat);
            if (Token != "")
            {
                request.Headers.Add($"\"Authorization\":\"Bearer {Token}\"");
            }
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

        public static string GetContent(string url)
        {
            var request = WebRequest.Create(url);
            request.Headers.Add("Accept: application/" + DataFormat);
            if (Token != "")
            {
                request.Headers.Add($"\"Authorization\":\"Bearer {Token}\"");
            }
            var response = request.GetResponse();
            var responseStream = response.GetResponseStream();
            var streamReader = new StreamReader(responseStream, Encoding.UTF8);
            var html = streamReader.ReadToEnd();
            response.Close();
            return html;
        }

        public static string GetMd5Hash(Stream stream)
        {
            var _md5 = MD5.Create().ComputeHash(stream);
            string md5 = "";
            foreach (var item in _md5)
            {
                md5 += Convert.ToString(item, 16);
            }
            return md5;
        }

        public static string GetMd5Hash(Stream stream, int size)
        {
            byte[] code = new byte[size];
            stream.Read(code, 0, code.Length);
            stream.Close();
            var _md5 = MD5.Create().ComputeHash(code);
            string md5 = "";
            foreach (var item in _md5)
            {
                md5 += Convert.ToString(item, 16);
            }
            return md5;
        }

        public static string GetMd5Hash(string input)
        {
            byte[] code = Encoding.Default.GetBytes(input);
            var _md5 = MD5.Create().ComputeHash(code);
            string md5 = "";
            foreach (var item in _md5)
            {
                md5 += Convert.ToString(item, 16);
            }
            return md5;
        }
    }
}