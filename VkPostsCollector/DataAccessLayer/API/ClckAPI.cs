using System.Collections.Specialized;

namespace VkPostsCollector.DataAccessLayer.API
{
    public static class ClckAPI
    {
        public static string ShortUrl(string URL)
        {
            WebData https = new WebData();

            string ApiPage = "https://clck.ru/--?url=";

            HttpResponse getResponese = https.GET(ApiPage + URL);
            if (getResponese == null)
                return null;

            return getResponese.Content;
        }
    }
}
