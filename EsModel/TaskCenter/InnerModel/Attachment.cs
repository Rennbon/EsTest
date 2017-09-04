using System;
using System.Collections.Generic;
using System.Text;
using Nest;
using Newtonsoft.Json;

namespace EsEntity.TaskCenter.InnerModel
{
    public class Attachment
    {
        [Keyword]
        [JsonProperty("fileId")]
        public string FileId { set; get; }
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        [JsonProperty("content")]
        public string Content { set; get; }
    }
}
