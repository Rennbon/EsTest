using System;
using System.Collections.Generic;
using System.Text;

namespace ESFramework.Estensions
{
    public static class DateExpands
    {
        /// <summary>
        /// 时间戳转本地时间
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static DateTime ToDate(this long _this)
        {
            System.DateTime startTime = TimeZoneInfo.ConvertTimeToUtc(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc).ToLocalTime();
            return startTime.AddMilliseconds(_this);
        }
    }
}
