using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ESFramework.Estensions
{
    public static class EntitySerializeExtends
    {
        /// <summary>
        /// es用实体局部update实体指定单个属性转json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string SerializeToDoc<T>(this T t, Expression<Func<object>> expression) where T : IESEntity
        {
            string propery = string.Empty;
            var body = expression.Body as MemberExpression;
            if (body != null)
            {
                propery = body.Member.Name;
            }
            string[] propertiesInculde = new string[1] { propery };
            string jsonString = JsonConvert.SerializeObject(t, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new IncludeContractResolver(propertiesInculde)
            });
            return jsonString;
        }
    }
}
