using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VkPostsCollector.BusinessLayer;

namespace VkPostsCollector.ApplicationLayer
{
    public static class Configs
    {
        public static string AccessToken = "20e0e7e620e0e7e620e0e7e6e420901b4d220e020e0e7e67e72e2ea810c2598e177d57b";
        public static string AdLink = "https://alitems.com/g/1e8d114494bd0482fb1316525dc3e8/";

        public static List<GroupDTO> Groups = new List<GroupDTO>();

        private static XmlSerializer GroupsSerializer = new XmlSerializer(typeof(List<GroupDTO>));
        private static string GroupsFileName = "Groups.exml";

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
    }
}
