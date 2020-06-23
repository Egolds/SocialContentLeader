/// Документация https://vk.com/dev/objects/post

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// DTO - Data Transfer Objects

namespace VkPostsCollector.BusinessLayer
{
    public class VkPublicationDTO
    {
        public string Id { get; set; }

        public GroupDTO Group { get; set; }

        public DateTime Created { get; set; }
        public string PostType { get; set; }
        public bool IsRepost { get; set; }
        public string PostLink { get; set; }

        public string Text { get; set; }

        public List<string> Links { get; set; } = new List<string>();
        public bool ExistsLinks { get; set; }

        /// <summary>
        /// Информация о том, что запись закреплена
        /// </summary>
        public bool IsPinned { get; set; }

        /// <summary>
        /// Информация о том, содержит ли запись отметку "реклама" (True/1 — да, False/0 — нет).
        /// </summary>
        public bool MarkedAsAds { get; set; }

        /// <summary>
        /// Информация о том, запись была опубликована от имени сообщества и подписана пользователем или нет
        /// </summary>
        public bool ExistsSigner { get; set; }

        /// <summary>
        /// Ссылка на профиль автора, если запись была опубликована от имени сообщества и подписана пользователем
        /// </summary>
        public string SignerLink { get; set; }

        /// <summary>
        /// Информация о том, содержит ли запись медиавложения (фотографии, ссылки и т.п.)
        /// </summary>
        public bool ExistsAttachments { get; set; }

        /// <summary>
        /// Информация о том, содержит ли запись фотографии
        /// </summary>
        public bool ExistsImages { get; set; }

        public List<string> ImageLinks { get; set; } = new List<string>();

        public decimal Comments { get; set; }
        public decimal Likes { get; set; }
        public decimal Reposts { get; set; }
        public decimal Views { get; set; }

        public decimal LikesCTR
        {
            get
            {
                return Math.Round(Likes / Views, 5, MidpointRounding.ToEven);
            }
        }

        // TODO: add ExistsSmiles, ExistsHashtags
    }

    public class TelegramPublicationDTO
    {
        public bool CanPublicate { get; set; } = true;

        //public bool IsPublicated { get; set; } = false;
        public string Error { get; set; } = string.Empty;

        public VkPublicationDTO VkPublication { get; set; }

        public string Text { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> Links { get; set; } = new List<string>();
    }

    [Serializable]
    public class GroupDTO
    {
        public string URL
        {
            get => "https://vk.com/" + ScreenName;
        }
        
        public string ScreenName { get; set; }

        public string Name { get; set; }

        public string PhotoUrl { get; set; }
    }
}
