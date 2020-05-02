using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace VkPostsCollector.DataAccessLayer.API
{
    public static class AdmitadAPI
    {
        public static string GetCleanUrl(string ShortURL)
        {
            string cleanLink = string.Empty;

            WebData https = new WebData();
            https.AllowAutoRedirect = true;
            HttpResponse getResponese = https.GET(ShortURL);
            if (getResponese == null)
                return null;

            string htmlBody = getResponese.Content;
            string[] htmlLines = Regex.Split(htmlBody, "\n");
            string targetLine = htmlLines.First(x => x.Contains("canonical"));
            if(string.IsNullOrEmpty(targetLine) == false)
            {
                cleanLink = Regex.Match(targetLine, "http([^(]*).html").Groups[0].Value;
            }

            return cleanLink;
        }

        public static string CreateUrl(string PartenerLink, string ProductURL)
        {
            string parameter = "?ulp=";
            if (PartenerLink.EndsWith("/") == false) parameter = "/" + parameter;

            string baseUrl = PartenerLink + parameter + WebUtility.UrlEncode(ProductURL);
            return baseUrl;

            // https://alitems.com/g/1e8d114494bd0482fb1316525dc3e8/
            // https://alitems.com/g/1e8d114494bd0482fb1316525dc3e8/?ulp=https%3A%2F%2Faliexpress.ru%2Fitem%2F32822822772.html
        }
    }
}
