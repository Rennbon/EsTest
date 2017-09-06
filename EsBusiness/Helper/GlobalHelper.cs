using ESFramework;
using ESFramework.Estensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsBusiness.Helper
{
    public class GlobalHelper<T> where T : IESEntity
    {
        public static string GetScriptInline(string prefix = "ctx._source", params TypeFeild<T>[] typeFeilds)
        {
            //"ctx._source.fid ='';ctx._source.fname= '';")

            //json出来是"{name:'123',id:"223"}"
            JObject obj = JObject.Parse(EntitySerializeExtends<T>.DeserializeObjectToSet(typeFeilds).ToString());
            StringBuilder sb = new StringBuilder();
            foreach (var item in obj)
            {
                sb.Append($"{prefix}.{item.Key}='{item.Value}';");
            }
            return sb.ToString();
        }
    }
}
