﻿using System;
using System.Collections.Generic;
using System.Text;
using Nest;
using Newtonsoft.Json;

namespace EsEntity.TaskCenter.InnerModel
{
    /// <summary>
    /// 附件实体
    /// </summary>
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
