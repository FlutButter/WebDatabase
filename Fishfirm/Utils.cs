using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishfirm
{
    public class Utils
    {
        public static bool CheckDate(string date)
        {
            var dateFormat = "yyyy.MM.dd";
            DateTime scheduleDate;
            if (DateTime.TryParseExact(date, dateFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate))
            {
                return true;
            }
            return false;
        }
        public static bool CheckNum(string num)
        {
            int i;
            if (int.TryParse(num, out i))
                return true;
            return false;
        }
    }
}
