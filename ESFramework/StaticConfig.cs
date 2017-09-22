using System;
using System.Collections.Generic;
using System.Text;

namespace ESFramework
{
    public static class StaticConfig
    {
        public static IEnumerable<string> TaskCenterUrls => JsonConfigReader.Configuration.GetSection("ESUrls:TaskCenterUrls").Value.Split("|");


        public const string IndexNameTaskCenter = "taskcenter";
        public const string TypeNameTask = "task";
        public const string TypeNameFolder = "folder";
        public const string DateTimeFormat1 = "yyyy-MM-dd HH:mm:ss.SSS";

    }
}
