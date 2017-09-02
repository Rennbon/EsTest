using System;
using System.Collections.Generic;
using System.Text;
using Nest;

namespace EsEntity.TaskCenter.InnerModel
{
    public class Attachment
    {
        [Keyword(Name = "fileId")]
        public string FileId { set; get; }
        [Text(Name = "content", Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        public string Content { set; get; }
    }
}
