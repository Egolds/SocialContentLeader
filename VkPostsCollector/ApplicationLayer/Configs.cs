using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using VkPostsCollector.BusinessLayer;

namespace VkPostsCollector.ApplicationLayer
{
    public static class Configs
    {
        public static string AccessToken { get; set; } = "20e0e7e620e0e7e620e0e7e6e420901b4d220e020e0e7e67e72e2ea810c2598e177d57b"; // Тут можно например ключ приложения вк, которое тоже надо создать: https://vk.com/apps?act=manage
        public static string TelegramToken { get; set; } = "830931210:AAFimSLygGF7heGe072dseukLAnwIBUI4BU"; // Токен бота в телеге
        public static string AdLink { get; set; } = "https://alitems.com/g/1e8d114494bd0482fb1316525dc3e8/";
        public static string TelegramChannel { get; set; } = "@clickandbuy";
        
        public static List<GroupDTO> Groups = new List<GroupDTO>();
        public static PublicationFilters PublicationFilters = new PublicationFilters();

        private static XmlSerializer GroupsSerializer = new XmlSerializer(typeof(List<GroupDTO>));
        private static string GroupsFileName = "Groups.exml";

        private static XmlSerializer FiltersSerializer = new XmlSerializer(typeof(PublicationFilters));
        private static string FiltersFileName = "Filters.exml";

        public static void GroupsLoad()
        {
            if (File.Exists(GroupsFileName) == false) return;

            using (FileStream fs = new FileStream(GroupsFileName, FileMode.OpenOrCreate))
            {
                Groups = (List<GroupDTO>)GroupsSerializer.Deserialize(fs);
            }
        }
        public static void GroupsSave()
        {
            using (FileStream fs = new FileStream(GroupsFileName, FileMode.OpenOrCreate))
            {
                GroupsSerializer.Serialize(fs, Groups);
            }
        }

        public static void FiltersLoad()
        {
            if (File.Exists(FiltersFileName) == false) return;

            using (FileStream fs = new FileStream(FiltersFileName, FileMode.OpenOrCreate))
            {
                PublicationFilters = (PublicationFilters)FiltersSerializer.Deserialize(fs);
            }
        }
        public static void FiltersSave()
        {
            using (FileStream fs = new FileStream(FiltersFileName, FileMode.OpenOrCreate))
            {
                FiltersSerializer.Serialize(fs, PublicationFilters);
            }
        }
    }
}
