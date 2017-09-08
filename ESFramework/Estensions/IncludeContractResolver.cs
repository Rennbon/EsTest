using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESFramework.Estensions
{
    /// <summary>
    /// 只获取指定key生成json
    /// </summary>
    public class IncludeContractResolver : DefaultContractResolver
    {
        IEnumerable<string> lstInclude;
        public IncludeContractResolver(IEnumerable<string> includedProperties)
        {
            lstInclude = includedProperties;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).Where(p => lstInclude.Contains(p.UnderlyingName)).ToList();
        }
    }
}
