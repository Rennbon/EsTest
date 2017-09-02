using System;
using System.Collections.Generic;
using System.Text;
using Nest;
using System.Linq;
using Elasticsearch.Net;
using System.Reflection;
using ESFramework;

namespace EsBusiness.EsBase
{
    public abstract class EsDomain
    {
        
        //public ConnectionSettings connectionSettings;
        public ElasticClient client ;
        public EsDomain(Dictionary<Type, string> typeIndexDic, IEnumerable<string> urls)
        {
        
            var uris = urls.Select(o => new Uri(o));
            var nodes = uris.Select(u => new Node(u));
            var pool = new StickyConnectionPool(nodes);
            var connectionSettings = new ConnectionSettings(pool);
            foreach (var dic in typeIndexDic)
            {
                connectionSettings = connectionSettings.MapDefaultTypeIndices(i =>
                i.Add(dic.Key, dic.Value));
            }
            client = new ElasticClient(connectionSettings);
        }
       
    }
}
