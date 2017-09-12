using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsEntity.TaskCenter.InnerModel
{
    [Serializable]
    public class TaskDiscussion
    {
        [Keyword]
        [JsonProperty("discid")]
        public string DiscussionId { set; get; }


        /// <summary>
        /// 讨论内容
        /// </summary>
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        [JsonProperty("msg")]
        public string Message { set; get; }

        /// <summary>
        /// 被提及的人，inbox计数用到
        /// </summary>
        [Keyword]
        [JsonProperty("mentionaids")]
        public List<string> MentionedAccountIds { set; get; }
    }
}
