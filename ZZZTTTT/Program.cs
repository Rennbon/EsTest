using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZZTTTT
{
    class Program
    {
        static void Main(string[] args)
        {
            long a = GetTimeStampMilliseconds(DateTime.Now);
            string b;
            Console.WriteLine(DateTime.FromBinary(0));
            Console.Read();
        }
        static long GetTimeStampMilliseconds(DateTime _this)
        {
            TimeSpan time = _this.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(time.TotalMilliseconds);
        }
        static DateTime ToDate(long _this)
        {
            System.DateTime startTime = TimeZoneInfo.ConvertTimeToUtc(new System.DateTime(1970, 1, 1),TimeZoneInfo.Utc);
            // 当地时区
            DateTime dt = startTime.AddMilliseconds(_this).ToLocalTime();
            return dt;
        }
    }
}
