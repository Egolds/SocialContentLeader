using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;
using VkPostsCollector.ApplicationLayer;
using VkPostsCollector.BusinessLayer;

namespace VkPostsCollector.DataAccessLayer.API
{
    public static class TelegramAPI
    {
        public static bool SendPublicationAsync(TelegramPublicationDTO telegramPublicationDTO, bool UseImage = false)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // Да, телега только такой протокол поддерживает
                TelegramBotClient botClient = new TelegramBotClient(Configs.TelegramToken);
                var me = botClient.GetMeAsync().Result;
                ChatId chatId = new ChatId(Configs.TelegramChannel);

                Task<Telegram.Bot.Types.Message> message = null;

                if (UseImage == false)
                {
                    message = botClient.SendTextMessageAsync(chatId, telegramPublicationDTO.Text, Telegram.Bot.Types.Enums.ParseMode.Default, true, true);
                }
                else
                {
                    message = botClient.SendPhotoAsync(chatId, telegramPublicationDTO.PhotoUrl, telegramPublicationDTO.Text, Telegram.Bot.Types.Enums.ParseMode.Default, true);
                }

                if (message.Exception != null)
                {
                    //MessageBox.Show(message.Exception.Message);
                    return false;
                }

                if (message.Result == null)
                {
                    //MessageBox.Show("Результат вернул NULL");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
