using System;

namespace Tsq.HumanizeDateTime
{
    public static class HumanizeDateTime
    {
        public static string Humanize(this DateTime dateTime)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);
            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "1秒前" : ts.Seconds + "秒前";

            if (delta < 2 * MINUTE)
                return "1分钟前";

            if (delta < 45 * MINUTE)
                return ts.Minutes + "分钟前";

            if (delta < 90 * MINUTE)
                return "1小时前";

            if (delta < 24 * HOUR)
                return ts.Hours + "小时前";

            if (delta < 48 * HOUR)
                return "昨天";

            if (delta < 30 * DAY)
                return ts.Days + "天前";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "1个月前" : months + "个月前";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "1年前" : years + "年前";
            }
        }
    }
}
