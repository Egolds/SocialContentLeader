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
            string targetLine = htmlLines.FirstOrDefault(x => x.Contains("canonical"));
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
        }
    }
}
