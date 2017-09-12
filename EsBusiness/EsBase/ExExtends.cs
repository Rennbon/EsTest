using ESFramework;
using ESFramework.Estensions;
using ESFramework.Exceptions;
using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EsBusiness.EsBase
{
    class ExExtends<T> where T : IESEntity
    {

        /// <summary>
        /// 序列化指定对象的指定单个属性（主要用于es update doc）
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Object DeserializeObjectToSet<TField>(Expression<Func<T, TField>> field, TField value)
        {
            var json = EntitySerializeExtends<T>.SerializeObject<TField>(field, value);
            return JsonConvert.DeserializeObject(json);
        }

        /// <summary>
        /// 获取scriptInline修改字符串，ctx._id同层和ctx._source的不支持一次性获取，如有需要再拓展
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="typeFeilds"></param>
        /// <returns></returns>
        public static string GetScriptInlineToSet(string prefix = "ctx._source", params TypeFeild<T>[] typeFeilds)
        {
            //"ctx._source.fid ='';ctx._source.fname= '';")

            //json出来是"{name:'123',id:"223"}"
            JObject obj = JObject.Parse(EntitySerializeExtends<T>.SerializeObject(typeFeilds));
            string inline = string.Empty;
            foreach (var item in obj)
            {
                inline = $"{prefix}.{item.Key}='{item.Value}';";
            }
            return inline;
        }
        /// <summary>
        /// 获取document 内嵌数组添加script
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static Func<ScriptDescriptor, IScript> GetScriptInlineToAddFisrtElement<TField>(Expression<Func<T, TField>> field, TField value, string prefix = "ctx._source") where TField : IEnumerable
        {
            //"script": {
            //    "inline": "if (!ctx._source.atts.contains(params.att)){ ctx._source.atts.add(params.att)}",
            //    "params":{ "att":{ "fileId":"10002","attContent":"123"} }
            //}
            var v = value.GetEnumerator();
            if (!v.MoveNext())
            {
                throw new ESException($"{nameof(TField)}不能为空");
            }
            JObject obj = JObject.Parse(EntitySerializeExtends<T>.SerializeObject<TField>(field, value));
            string inline = string.Empty;

            object paramsValue = null;
            foreach (var item in obj)
            {
                inline = $"if(!{prefix}.{item.Key}.contains(params.value)){{ {prefix}.{item.Key}.add(params.value)}}";
                paramsValue = item.Value.First;
                break;
            }

            var dic = new Dictionary<string, object>();
            dic.Add("value", paramsValue);
            Func<ScriptDescriptor, IScript> result = sp => sp
             .Inline(inline)
             .Params(dic);
            return result;
        }
        /// <summary>
        /// 获取document 内嵌数组删除script 
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static Func<ScriptDescriptor, IScript> GetScriptInlineToRemoveFisrtElement<TField>(Expression<Func<T, TField>> field, TField value, string prefix = "ctx._source") where TField : IEnumerable
        {
            //"script": {
            //    "inline": "ctx._source.atts.remove(ctx._source.atts.indexOf(params.att))",
            //    "params":{ "att":{ "fileId":"10002","attContent":"123"} }
            //}
            var v = value.GetEnumerator();
            if (!v.MoveNext())
            {
                throw new ESException($"{nameof(TField)}不能为空");
            }
            JObject obj = JObject.Parse(EntitySerializeExtends<T>.SerializeObject<TField>(field, value));
            string inline = string.Empty;
            object paramsValue = null;
            foreach (var item in obj)
            {
                var a = item.Value;
                inline = $"{prefix}.{item.Key}.remove({prefix}.{item.Key}.indexOf(params.value))";
                paramsValue = item.Value.First;
                break;
            }

            var dic = new Dictionary<string, object>();
            dic.Add("value", paramsValue);
            Func<ScriptDescriptor, IScript> result = sp => sp
             .Inline(inline)
             .Params(dic);
            return result;
        }
        /// <summary>
        /// 移除实体内嵌array中的指定id的element(o=>o.list.first().xxId)
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field"></param>
        /// <param name="id"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static Func<ScriptDescriptor, IScript> GetScriptInlineToRemoveFisrtElementById<TField>(Expression<Func<T, TField>> field, string id, string prefix = "ctx._source") where TField : IEnumerable
        {
            //"script": {
            //    "inline": "for (int i = 0; i < ctx._source.atts.size(); i++) {if(ctx._source.atts[i].fileId == params.id){ctx._source.atts.remove(i);}}",
            //"params":{ "id":"10002"}
            //}
            var body = field.Body as MemberExpression;
            if (body == null)
            {
                throw new ESException("自定义EntitySerializeExtends方法，参数field.Body为空");
            }
            string childPropertyName = string.Empty;
            string parentPropertyName = string.Empty;
            var properties = body.Member.GetCustomAttributes(typeof(Newtonsoft.Json.JsonPropertyAttribute), false);

            var propertys2 = (body.Expression as MethodCallExpression).Arguments[0] as MemberExpression;

            var parentProperties = propertys2.Member.GetCustomAttributes(typeof(Newtonsoft.Json.JsonPropertyAttribute), false);
            if (properties.Length > 0)
            {
                childPropertyName = ((Newtonsoft.Json.JsonPropertyAttribute)properties[0]).PropertyName;
            }
            else
            {
                throw new ESException("自定义EntitySerializeExtends方法，参数field.Body为空");
            }
            if (parentProperties.Length > 0)
            {
                parentPropertyName = ((Newtonsoft.Json.JsonPropertyAttribute)parentProperties[0]).PropertyName;
            }
            else
            {
                throw new ESException("自定义EntitySerializeExtends方法，参数field.Body为空");
            }

            string str = $"for (int i = 0; i < ctx._source.{parentPropertyName}.size(); i++){{if(ctx._source.{parentPropertyName}[i].{childPropertyName}== params.id){{ctx._source.{parentPropertyName}.remove(i);}}}}";
            var dic = new Dictionary<string, object>();
            dic.Add("id", id);
            Func<ScriptDescriptor, IScript> result = sp => sp
             .Inline(str)
             .Params(dic);
            return result;
        }
    }
}
