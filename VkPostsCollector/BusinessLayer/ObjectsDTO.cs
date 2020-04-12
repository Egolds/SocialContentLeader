/// Документация https://vk.com/dev/objects/post

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkPostsCollector.BusinessLayer
{
    public class PublicationDTO
    {
        public string Id { get; set; }

        public GroupDTO Group { get; set; }
        public string GroupName { get; set; }
        public string GroupLink { get; set; }

        public DateTime Created { get; set; }
        public string PostType { get; set; }
        public string PostLink { get; set; }

        public string Text { get; set; }

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

        public List<string> ImageLinks { get; set; } = new List<string>();

        public decimal Comments { get; set; }
        public decimal Likes { get; set; }
        public decimal Reposts { get; set; }
        public decimal Views { get; set; }
    }

    public class GroupDTO
    {
        // TODO...
    }
}
