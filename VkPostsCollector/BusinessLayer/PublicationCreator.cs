using System.Windows.Forms;
using VkPostsCollector.ApplicationLayer;
using VkPostsCollector.DataAccessLayer.API;
using VkPostsCollector.BusinessLayer;

namespace VkPostsCollector.BusinessLayer
{
    public static class PublicationCreator
    {
        public static TelegramPublicationDTO CreateTelegramPublication(VkPublicationDTO post)
        {
            TelegramPublicationDTO telegramPost = new TelegramPublicationDTO();
            telegramPost.VkPublication = post;
            
            if (post.Links.Count > Configs.PublicationFilters.MaxQuantityAdLinks || post.Links.Count == 0)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            if(post.Likes > Configs.PublicationFilters.MaxQuantityLikes && Configs.PublicationFilters.MaxQuantityLikes > -1)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }
            if(post.Likes < Configs.PublicationFilters.MinQuantityLikes && Configs.PublicationFilters.MinQuantityLikes > -1)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            if (post.Comments > Configs.PublicationFilters.MaxQuantityComments && Configs.PublicationFilters.MaxQuantityComments > -1)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }
            if(post.Comments < Configs.PublicationFilters.MinQuantityComments && Configs.PublicationFilters.MinQuantityComments > -1)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            if (post.Reposts > Configs.PublicationFilters.MaxQuantityReposts && Configs.PublicationFilters.MaxQuantityReposts > -1)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }
            if(post.Reposts < Configs.PublicationFilters.MinQuantityReposts && Configs.PublicationFilters.MinQuantityReposts > -1)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            if(post.Text.Length > Configs.PublicationFilters.MaxQuantityChars)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            foreach (string keyword in Configs.PublicationFilters.KeyWordsBlackList)
            {
                if (post.Text.ToLower().Contains(keyword.ToLower()))
                {
                    if (string.IsNullOrWhiteSpace(keyword) == false)
                    {
                        telegramPost.CanPublicate = false;
                        return telegramPost;
                    }
                }
            }
            
            if (post.IsRepost && Configs.PublicationFilters.AllowReposts == false)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            if (post.IsPinned && Configs.PublicationFilters.AllowPinned == false)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            if (post.MarkedAsAds && Configs.PublicationFilters.AllowMarkedAsAds == false)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            if (post.ExistsSigner && Configs.PublicationFilters.AllowWithSigner == false)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            if (post.ImageLinks.Count == 0 && Configs.PublicationFilters.AllowPublicateWithoutImages == false)
            {
                telegramPost.CanPublicate = false;
                return telegramPost;
            }

            // AllowPublicateWithSmiles
            // AllowPublicateWithHashtags

            string FiltredText = post.Text;

            // TODO Filtration

            telegramPost.Text = FiltredText;

            if (post.ImageLinks.Count > 0)
            {
                telegramPost.PhotoUrl = post.ImageLinks[0];
            }

            foreach (string url in post.Links)
            {
                string MyPartnerUrl = ReplaceCompetitiveUrl(url);
                if (MyPartnerUrl == string.Empty)
                {
                    //MessageBox.Show("Не удалось получить партнерскую ссылку");
                    telegramPost.Error = "Не удалось получить партнерскую ссылку";
                    return telegramPost;
                }

                telegramPost.Text = telegramPost.Text.Replace(url, MyPartnerUrl);
                telegramPost.Links.Add(MyPartnerUrl);
            }
            
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
    }
}
