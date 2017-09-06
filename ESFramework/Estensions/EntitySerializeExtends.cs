using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ESFramework.Estensions
{
    /// <summary>
    /// json序列化拓展
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntitySerializeExtends<T> where T : IESEntity
    {
        /// <summary>
        /// 序列化指定对象的指定单个属性（主要用于es update doc）
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object DeserializeObjectToSet<TField>(Expression<Func<T, TField>> field, TField value)
        {
            string property = string.Empty;
            var body = field.Body as MemberExpression;
            if (body == null)
            {
                throw new NullReferenceException("自定义EntitySerializeExtends方法，参数field.Body为空");
            }
            property = body.Member.Name;
            Type o = typeof(T);//加载类型
            object obj = Activator.CreateInstance(o, true);//根据类型创建实例
            var t = (T)obj;
            var fieldPropertyInfo = o.GetProperty(property);
            fieldPropertyInfo.SetValue(t, value);
            string[] propertiesInculde = new string[1] { property };
            string jsonString = JsonConvert.SerializeObject(t, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new IncludeContractResolver(propertiesInculde),

            });
            return JsonConvert.DeserializeObject(jsonString);
        }
        /// <summary>
        /// 序列化指定对象的指定单个属性（主要用于es update doc）
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object DeserializeObjectToSet(params TypeFeild<T>[] typeFeilds)
        {
            List<string> propertiesInculde = new List<string>();
            Type o = typeof(T);//加载类型
            object obj = Activator.CreateInstance(o, true);//根据类型创建实例
            var t = (T)obj;
            foreach (var item in typeFeilds)
            {
                string property = string.Empty;
                var body = item.Field.Body as MemberExpression;
                if (body == null)
                {
                    throw new NullReferenceException("自定义EntitySerializeExtends方法，参数field.Body为空");
                }
                property = body.Member.Name;
                var fieldPropertyInfo = o.GetProperty(property);
                fieldPropertyInfo.SetValue(t, item.Value);
                propertiesInculde.Add(property);
            }
            string jsonString = JsonConvert.SerializeObject(t, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new IncludeContractResolver(propertiesInculde),

            });
            return JsonConvert.DeserializeObject(jsonString);
        }
    }
}
