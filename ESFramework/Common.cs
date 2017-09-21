using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ESFramework
{
    public class Common
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        public static string GetEnumDesc<T>(T enumtype)
        {
            if (enumtype == null) throw new ArgumentNullException("enumtype");
            if (!enumtype.GetType().IsEnum) throw new Exception("参数类型不正确");
            return ((DescriptionAttribute)enumtype.GetType().GetField(enumtype.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description;
        }
        public static DateTime ConvertToDateTime(long jsTimeStamp)
        {
            System.DateTime startTime = new DateTime(1970, 1, 1);// 当地时区
            return startTime.AddMilliseconds(jsTimeStamp);
        }
    }
}
