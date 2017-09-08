using ESFramework;
using ESFramework.Estensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EsBusiness.Helper
{
    public class GlobalHelper<T> where T : IESEntity
    {

        ///// <summary>
        ///// 序列化指定对象的指定单个属性（主要用于es update doc）
        ///// </summary>
        ///// <typeparam name="TField"></typeparam>
        ///// <param name="field"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static Object DeserializeObjectToSet<TField>(Expression<Func<T, TField>> field, TField value)
        //{
        //    var json = EntitySerializeExtends<T>.SerializeObject<TField>(field, value);
        //    return JsonConvert.DeserializeObject(json);
        //}

        ///// <summary>
        ///// 获取scriptInline修改字符串，ctx._id同层和ctx._source的不支持一次性获取，如有需要再拓展
        ///// </summary>
        ///// <param name="prefix"></param>
        ///// <param name="typeFeilds"></param>
        ///// <returns></returns>
        //public static string GetScriptInlineToSet(string prefix = "ctx._source", params TypeFeild<T>[] typeFeilds)
        //{
        //    //"ctx._source.fid ='';ctx._source.fname= '';")

        //    //json出来是"{name:'123',id:"223"}"
        //    JObject obj = JObject.Parse(EntitySerializeExtends<T>.SerializeObject(typeFeilds));
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in obj)
        //    {
        //        sb.Append($"{prefix}.{item.Key}='{item.Value}';");
        //    }
        //    return sb.ToString();
        //}

        //public static string GetScriptInlineToAddFisrtParam<IEnumerable>(Expression<Func<T, IEnumerable>> field, TField value, string prefix = "ctx._source") where TField : IEnumerable
        //{
        //    //{
        //    //"script" : "for (int i = 0; i < ctx.source.views.size(); i++) {if(ctx.source.views[i].user == view.user){ctx.source.views[i].count++;} else {ctx.source.views.add(view)}}",
        //    //"lang": "groovy",
        //    //"params": {
        //    //"view": {"user":"tt99", "count":1}
        //    //ctx._source.atts.add()

        //    value.First()



        //    JObject obj = JObject.Parse(EntitySerializeExtends<T>.SerializeObject<TField>(field, value));
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var item in obj)
        //    {
        //        sb.Append($"{prefix}.{item.Key}.add({item.Value};");
        //        break;
        //    }
        //    return sb.ToString();
        //}
    }
}
