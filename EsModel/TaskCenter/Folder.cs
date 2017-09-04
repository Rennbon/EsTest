using ESFramework;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsEntity.TaskCenter
{
    [ElasticsearchType(Name = EsSysConfig.TypeNameFolder, IdProperty = nameof(FolderID))]
    public class Folder : EntityBase
    {
        /// <summary>
        /// 项目id
        /// </summary>
        [Keyword]
        [JsonProperty("id")]
        public string FolderID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        [JsonProperty("name")]
        public string FolderName { get; set; }
        /// <summary>
        /// 负责人id
        /// </summary>
        [Keyword]
        [JsonProperty("chargeId")]
        public string ChargeAccountID { get; set; }

        [Boolean]
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        /// <summary>
        /// 归档与否
        /// </summary>
        [Boolean]
        [JsonProperty("archived")]
        public bool Archived { get; set; }
        /// <summary>
        /// 群组id
        /// </summary>
        [Keyword]
        [JsonProperty("groupids")]
        public List<string> GroupIds { get; set; }
        /// <summary>
        /// 有效成员Id
        /// </summary>
        [Keyword]
        [JsonProperty("memberids")]
        public List<string> MemberIds { set; get; }
        /// <summary>
        /// 项目详情
        /// </summary>
        [Text(Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        [JsonProperty("content")]
        public string Content { get; set; }

    }
}
