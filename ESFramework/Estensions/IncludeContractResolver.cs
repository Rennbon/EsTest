using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESFramework.Estensions
{
    public class IncludeContractResolver: DefaultContractResolver
    {
        IEnumerable<string> lstInclude;
        public IncludeContractResolver(IEnumerable<string> includedProperties)
        {
            lstInclude = includedProperties;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).ToList().FindAll(p => lstInclude.Contains(p.PropertyName));
        }
    }
}
