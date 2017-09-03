using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESFramework.Estensions
{
    public class CustomContractResolver: DefaultContractResolver
    {
        IEnumerable<string> lstExclude;
        public CustomContractResolver(IEnumerable<string> excludedProperties)
        {
            lstExclude = excludedProperties;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).ToList().FindAll(p => !lstExclude.Contains(p.PropertyName));
        }
    }
}
