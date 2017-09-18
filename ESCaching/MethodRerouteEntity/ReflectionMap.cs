using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCaching.MethodRerouteEntity
{
    public class ReflectionMap
    {
        public ReflectionMap(string name, object[] arguments, Type reflectedType)
        {
            Name = name;
            Arguments = arguments;
            ReflectedType = reflectedType;
        }
        public string Name { set; get; }
        public object[] Arguments { set; get; }
        public Type ReflectedType { set; get; }

    }
}
