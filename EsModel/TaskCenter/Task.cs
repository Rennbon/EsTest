using EsEntity.TaskCenter.InnerModel;
using EsEnum.TaskCenter;
using ESFramework;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsEntity.TaskCenter
{
    /// <summary>
    /// 任务实体
    /// </summary>
    [ElasticsearchType(Name = EsSysConfig.TypeNameTask, IdProperty = nameof(TaskId))]
    [Serializable]
    public class Task : EntityBase
    {
        /// <summary>
        /// 任务id
        /// </summary>
        [Keyword]
        [JsonProperty("id", Required = Required.Always)]
        public string TaskId { get; set; }
        /// <summary>
        /// 任务名
        /// </summary>
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word", Boost = 3)]
        [JsonProperty("name")]
        public string TaskName { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        [Keyword(EagerGlobalOrdinals = true)]
        [JsonProperty("fid")]
        public string FolderId { get; set; }
        /// <summary>
        /// 项目名
        /// </summary>
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        [JsonProperty("fname")]
        public string FolderName { get; set; }

        /// <summary>
        /// 母任务id
        /// </summary>
        [Keyword]
        [JsonProperty("parentid")]
        public string ParentId { get; set; }

        /// <summary>
        /// 任务详情
        /// </summary>
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        [JsonProperty("content")]
        public string Content { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Date(Format = "yyyy-MM-dd HH:mm:ss.SSS")]
        [JsonProperty("starttime")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        [Date(Format = "yyyy-MM-dd HH:mm:ss.SSS")]
        [JsonProperty("endtime")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 负责人id
        /// </summary>
        [Keyword]
        [JsonProperty("chargeaid")]
        public string ChargeAccountId { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        [Number]
        [JsonProperty("status")]
        public int Status { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        [Date(Format = "yyyy-MM-dd HH:mm:ss.SSS")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("completetime")]
        public DateTime CompleteTime { get; set; }

        /// <summary>
        /// 有效成员id
        /// </summary>
        [Keyword]
        [JsonProperty("memberids")]
        public List<string> MemberIds { set; get; }
        /// <summary>
        /// 关键字，不存任务名
        /// </summary>
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        [JsonProperty("kw")]
        public List<string> Keywords { set; get; }

        /// <summary>
        /// 附件集合
        /// </summary>
        [Object]
        [JsonProperty("atts")]
        public List<InnerModel.Attachment> Attachments { set; get; }
        /// <summary>
        /// 讨论
        /// </summary>
        [Object]
        [JsonProperty("discs")]
        public List<TaskDiscussion> Discussions { set; get; }

    }
}
