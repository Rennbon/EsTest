using System;
using System.Collections.Generic;
using System.Text;

namespace ESFramework
{
    public static class EsSysConfig
    {
        public static IEnumerable<string> TaskCenterUrl => new List<string>{    "http://localhost:9200",
        "http://localhost:9201",
        "http://localhost:9202" };

        public const string IndexNameTaskCenter = "taskcenter";
        public const string TypeNameTask = "task";
        public const string TypeNameFolder = "folder";
        public const string TypeNameTaskDiscussion = "taskDisc";
        public const string TypeNameFolderDiscussion = "folderDisc";

        public const string DateTimeFormat1 = "yyyy-MM-dd HH:mm:ss.SSS";

    }
}
