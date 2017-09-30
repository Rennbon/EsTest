using System;
using System.Collections.Generic;
using System.Text;

namespace ESFramework.CustomAttributes
{
    /// <summary>
    /// es请求重新路由
    /// </summary>
    public class TCRerouteAttribute: Attribute
    {
        /// <summary>
        /// 路由分组
        /// </summary>
        public TaskMQQroup Group { set; get; }
        public TCRerouteAttribute(TaskMQQroup group = TaskMQQroup.Defualt)
        {
            Group = group;
        }
    }
    /// <summary>
    /// 分组
    /// </summary>
    public enum TaskMQQroup
    {
        Defualt = 0,
        GroupOne = 1,
        GroupTwo = 2,
    }
}
