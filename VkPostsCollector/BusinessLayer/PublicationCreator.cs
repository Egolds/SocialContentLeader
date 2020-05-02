using System.Windows.Forms;
using VkPostsCollector.ApplicationLayer;
using VkPostsCollector.DataAccessLayer.API;

namespace VkPostsCollector.BusinessLayer
{
    public static class PublicationCreator
    {
        public static TelegramPublicationDTO CreateTelegramPublication(VkPublicationDTO post)
        {
            TelegramPublicationDTO telegramPost = new TelegramPublicationDTO();

            telegramPost.Text = post.Text;
            telegramPost.PhotoUrl = post.ImageLinks[0];

            foreach (string url in post.Links)
            {
                string MyPartnerUrl = ReplaceCompetitiveUrl(url);
                if (MyPartnerUrl == string.Empty)
                {
                    MessageBox.Show("Не удалось получить партнерскую ссылку");
                    return null;
                }

                telegramPost.Text = telegramPost.Text.Replace(url, MyPartnerUrl);
                telegramPost.Links.Add(MyPartnerUrl);
            }

            telegramPost.Text = ApplyFilters(telegramPost.Text);

            return telegramPost;
        }
        
        private static string ReplaceCompetitiveUrl(string competitiveUrl)
        {
            string cleanLink = AdmitadAPI.GetCleanUrl(competitiveUrl);
            if(cleanLink == string.Empty)
                return string.Empty;

            string link = AdmitadAPI.CreateUrl(Configs.AdLink, cleanLink);
            string ShortPartnerUrl = IsgdAPI.ShortUrl(link);

            return ShortPartnerUrl;
        }

        private static string ApplyFilters(string OriginalText)
        {
            string FiltredText = OriginalText;

            return FiltredText;
        }
    }
}
