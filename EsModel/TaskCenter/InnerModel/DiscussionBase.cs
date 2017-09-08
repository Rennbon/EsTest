using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsEntity.TaskCenter.InnerModel
{
    /// <summary>
    /// 讨论实体
    /// </summary>
    [Serializable]
    public class DiscussionBase : EntityBase
    {
        [Keyword]
        [JsonProperty("id")]
        public string DiscussionId
        {
            get { return string.IsNullOrEmpty(_discussionId) ? string.Empty : _discussionId.ToLower(); }
            set { _discussionId = value; }
        }
        /// <summary>
        /// 依附主体id
        /// </summary>
        [Keyword]
        [JsonProperty("sid")]
        public string SourceId
        {
            get { return string.IsNullOrEmpty(_sourceId) ? string.Empty : _sourceId.ToLower(); }
            set { _sourceId = value; }
        }

        /// <summary>
        /// 被回复的讨论id
        /// </summary>
        [Keyword]
        [JsonProperty("replyid")]
        public string ReplyId
        {
            get { return string.IsNullOrEmpty(_replyId) ? string.Empty : _replyId.ToLower(); }
            set { _replyId = value; }
        }
        /// <summary>
        /// 被回复的讨论创建者（冗余）
        /// </summary>
        [Keyword]
        [JsonProperty("replyaid")]
        public string ReplyAccountId
        {
            get { return string.IsNullOrEmpty(_replyAccountId) ? string.Empty : _replyAccountId.ToLower(); }
            set { _replyAccountId = value; }
        }
        /// <summary>
        /// 附件类型
        /// </summary>
        [Number]
        [JsonProperty("filetype")]
        public int FileType { get; set; }
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
        public List<string> MentionedAccountIds
        {
            get { return _mentionedAccountIds ?? new List<string>(); }
            set
            {
                _mentionedAccountIds =
                    (value ?? new List<string>()).Select(o => (o ?? string.Empty).ToLower()).Distinct().ToList();
            }
        }
        [Object]
        [JsonProperty("atts")]
        public List<Attachment> Attachments { set; get; }
        private string _discussionId;
        private string _sourceId;
        private string _replyId;
        private string _replyAccountId;
        private List<string> _mentionedAccountIds;
    }
}
