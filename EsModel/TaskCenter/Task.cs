using EsEnum.TaskCenter;
using ESFramework;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsEntity.TaskCenter
{
    [ElasticsearchType(Name = EsSysConfig.TypeNameTask, IdProperty = nameof(TaskID))]
    public class Task : EntityBase
    {
        /// <summary>
        /// 任务id
        /// </summary>
        [Keyword(Name = "id")]
        public string TaskID { get; set; }
        /// <summary>
        /// 任务名
        /// </summary>
        [Text(Name = "name", Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word", Boost = 3)]
        public string TaskName { get; set; }
        /// <summary>
        /// 项目id
        /// </summary>
        [Keyword(Name = "fid", EagerGlobalOrdinals = true)]
        public string FolderID { get; set; }
        /// <summary>
        /// 项目名
        /// </summary>
        [Text(Name = "fname", Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        public string FolderName { get; set; }

        /// <summary>
        /// 母任务id
        /// </summary>
        [Keyword(Name = "parentid")]
        public string ParentID { get; set; }

        /// <summary>
        /// 任务详情
        /// </summary>
        [Text(Name = "content", Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        public string Content { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Date(Name = "starttime", Format = "yyyy-MM-dd HH:mm:ss")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        [Date(Name = "endtime", Format = "yyyy-MM-dd HH:mm:ss")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 负责人id
        /// </summary>
        [Keyword(Name = "chargeaid")]
        public string ChargeAccountID { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        [Number(Name = "status")]
        public int Status { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        [Date(Name = "completetime", Format = "yyyy-MM-dd HH:mm:ss")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CompleteTime { get; set; }

        /// <summary>
        /// 有效成员id
        /// </summary>
        [Keyword(Name = "memberids")]
        public List<string> MemberIds { set; get; }
        /// <summary>
        /// 关键字，不存任务名
        /// </summary>
        [Text(Name = "kw", Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        public List<string> Keywords { set; get; }
   
    }
}
