using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Constant
{
    public  class WeekOfDay
    {
        public static int WeekNow = (DateTime.Now.DayOfYear-2)/7;
        public static int WeekNext = WeekNow+1;
        public static string dayNow = DateTime.Now.ToShortDateString();
        
        

    }
}