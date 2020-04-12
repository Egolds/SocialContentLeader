using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkPostsCollector.ApplicationLayer.Common
{
    public static class Converters
    {
        public static DateTime UnixTimeToDateTime(long unixtime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return dtDateTime;
        }

        public static bool StringBitToBool(string BoolStringValue)
        {
            return BoolStringValue == "0" ? false : true;
        }

        public static string BoolToText(bool BoolValue)
        {
            if (BoolValue) return "Да";
            else return "Нет";
        }
    }
}
