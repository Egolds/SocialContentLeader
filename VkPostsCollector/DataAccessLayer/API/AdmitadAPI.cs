using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VkPostsCollector.DataAccessLayer.API
{
    public static class AdmitadAPI
    {
        public static string GetCleanUrl(string ShortURL)
        {
            return string.Empty;
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

        public static string ShortUrl(string URL)
        {
            return string.Empty;
        }
    }
}
