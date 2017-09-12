using System;
using System.Collections.Generic;
using System.Text;
using Nest;
using Newtonsoft.Json;

namespace EsEntity.TaskCenter.InnerModel
{
    /// <summary>
    /// 附件实体
    /// </summary>
    [Serializable]
    public class Attachment
    {
        [Keyword]
        [JsonProperty("fileId", Order = 1)]
        public string FileId { set; get; }
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        [JsonProperty("attContent")]
        public string AttContent { set; get; }
    }
}
