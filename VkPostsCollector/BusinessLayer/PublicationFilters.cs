using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VkPostsCollector.BusinessLayer
{
    public class PublicationFilters
    {
        /// <summary>
        /// Макс кол-во рекламных ссылок в публикации
        /// </summary>
        public decimal MaxQuantityAdLinks { get; set; } = 3;

        /// <summary>
        /// Максимальное кол-во лайков
        /// </summary>
        public decimal MaxQuantityLikes { get; set; } = -1;
        /// <summary>
        /// Минимальное кол-во лайков
        /// </summary>
        public decimal MinQuantityLikes { get; set; } = -1;

        /// <summary>
        /// Максимальное кол-во комментариев
        /// </summary>
        public decimal MaxQuantityComments { get; set; } = -1;
        /// <summary>
        /// Минимальное кол-во комментариев
        /// </summary>
        public decimal MinQuantityComments { get; set; } = 0;

        /// <summary>
        /// Максимальное кол-во репостов
        /// </summary>
        public decimal MaxQuantityReposts { get; set; } = -1;
        /// <summary>
        /// Минимальное кол-во репостов
        /// </summary>
        public decimal MinQuantityReposts { get; set; } = 0;

        /// <summary>
        /// Максимальное кол-во символов в записи
        /// </summary>
        public decimal MaxQuantityChars { get; set; } = 1000;

        /// <summary>
        /// Черный список ключевых слов
        /// </summary>
        public List<string> KeyWordsBlackList { get; set; } = new List<string>();

        public bool AllowReposts { get; set; } = false;

        public bool AllowPinned { get; set; } = false;

        public bool AllowMarkedAsAds { get; set; } = false;

        public bool AllowWithSigner { get; set; } = false;

        public bool AllowPublicateWithoutImages { get; set; } = false;

        public bool AllowPublicateWithSmiles { get; set; } = false;
        public bool SendToVerificationWithSmiles { get; set; } = true;
        public bool DeleteSmilesFromPublication { get; set; } = false;

        public bool AllowPublicateWithHashtags { get; set; } = false;
        public bool SendToVerificationWithHashtags { get; set; } = true;
        public bool DeleteHashtagsFromPublication { get; set; } = false;



        /// <summary>
        /// Приоритет записи с наибольшим CTR для лайков
        /// </summary>
        //public  bool IsCTRForLikesInPriority { get; set; } = true;


        /// <summary>
        /// Приоритет записей
        /// </summary>
        public PriorityEnum Priority { get; set; } = PriorityEnum.LikesCTR;
        public enum PriorityEnum
        {
            LikesCTR,
            Likes,
            Comments,
            Reposts
        }

        /// <summary>
        /// Кол-во постов с одной группы
        /// </summary>
        public decimal QuantityPostsFromGroup { get; set; } = 2;

        /// <summary>
        /// Максимальное кол-во постов в день
        /// </summary>
        public decimal MaxQuantityPostsDaily { get; set; } = 10;
        /// <summary>
        /// Минимальное кол-во постов в день
        /// </summary>
        public decimal MinQuantityPostsDaily { get; set; } = 10;



        /// <summary>
        /// Количество обрабатываемых последних постов на группу
        /// </summary>
        public int QuantityProcessLastPostsPerGroup { get; set; } = 30;

        /// <summary>
        /// Публиковать с (Время)
        /// </summary>
        [XmlIgnore]
        public TimeSpan PublicateTimeFrom { get; set; } = new TimeSpan(0, 0, 0);
        [XmlElement("PublicateTimeFrom")]
        public string PublicateTimeFrom_String
        {
            get { return PublicateTimeFrom.ToString("hh\\:mm\\:ss"); }
            set { PublicateTimeFrom = TimeSpan.Parse(value); }
        }

        /// <summary>
        /// Публиковать до (Время 24)
        /// </summary>
        [XmlIgnore]
        public TimeSpan PublicateTimeTo { get; set; } = new TimeSpan(6, 0, 0);
        [XmlElement("PublicateTimeTo")]
        public string PublicateTimeTo_String
        {
            get { return PublicateTimeTo.ToString("hh\\:mm\\:ss"); }
            set { PublicateTimeTo = TimeSpan.Parse(value); }
        }
    }
}
