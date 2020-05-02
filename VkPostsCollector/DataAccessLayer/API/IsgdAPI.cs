namespace VkPostsCollector.DataAccessLayer.API
{
    public static class IsgdAPI
    {
        public static string ShortUrl(string URL)
        {
            WebData https = new WebData();

            string ApiPage = "https://is.gd/create.php?format=simple&url=";
            
            HttpResponse getResponese = https.GET(ApiPage + URL);
            if (getResponese == null)
                return null;

            return getResponese.Content;
        }
    }
}
