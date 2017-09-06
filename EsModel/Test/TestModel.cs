using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsEntity.Test
{
    [ElasticsearchType(Name ="TestModel", IdProperty = nameof(Id))]
    public class TestModel
    {
        public string Id { set; get; }
        /// <summary>
        /// 任务名
        /// </summary>
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word", Boost = 3)]
        [JsonProperty("name")]
        public string Name { set; get; }
    }
}
