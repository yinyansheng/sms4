using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chatClient
{
    class TimeUtil
    {

        //获取当前时刻
        public static TimeSpan getNowTimeTicks() { 
            return new TimeSpan(DateTime.Now.Ticks);
        }

        public static string getSpanTime(TimeSpan startTime, TimeSpan endTime) {
            TimeSpan ts = endTime.Subtract(startTime).Duration();
            String spanTime = ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分" + ts.Seconds.ToString() + "秒";
            return spanTime;
        }

        public static string getNowTime() {
            string dateTime = DateTime.Now.ToString().Substring(5);
            return dateTime;
        }

        //获取1970-1-1到现在的毫秒数
        public static string getTicks() {

            TimeSpan ts = System.DateTime.Now.Subtract(DateTime.Parse("1970-1-1"));

            double diffMilliseconds = Convert.ToSingle(ts.TotalMilliseconds);

            return diffMilliseconds.ToString();
        }


    }
}
