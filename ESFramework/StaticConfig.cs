using System;
using System.Collections.Generic;
using System.Text;

namespace ESFramework
{
    public static class StaticConfig
    {
        public static IEnumerable<string> TaskCenterUrl => new List<string>{    "http://localhost:9200",
        "http://localhost:9201",
        "http://localhost:9202" };

        public const string IndexNameTaskCenter = "taskcenter";
        public const string TypeNameTask = "task";
        public const string TypeNameFolder = "folder";
        public const string DateTimeFormat1 = "yyyy-MM-dd HH:mm:ss.SSS";

    }
}
