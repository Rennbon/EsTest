using System;
using System.Collections.Generic;
using System.Text;

namespace ESFramework.CustomAttributes
{
    /// <summary>
    /// es请求重新路由
    /// </summary>
    public class RerouteAttribute : Attribute
    {
        /// <summary>
        /// 路由分组
        /// </summary>
        public RerouteGroupType Group { set; get; }
        public RerouteAttribute(RerouteGroupType group = RerouteGroupType.Defualt)
        {
            Group = group;
        }
    }
    /// <summary>
    /// 分组
    /// </summary>
    public enum RerouteGroupType
    {
        Defualt = 0,
        GroupOne = 1,
        GroupTwo = 2,
    }
}
