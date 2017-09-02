using ESFramework;
using Nest;
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
        [Keyword(Name = "id")]
        public string FolderID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Text(Name = "name", Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        public string FolderName { get; set; }
        /// <summary>
        /// 负责人id
        /// </summary>
        [Keyword(Name = "chargeId")]
        public string ChargeAccountID { get; set; }

        [Boolean(Name = "visibility")]
        public int Visibility { get; set; }
        /// <summary>
        /// 归档与否
        /// </summary>
        [Boolean(Name = "archived")]
        public bool Archived { get; set; }
        /// <summary>
        /// 群组id
        /// </summary>
        [Keyword(Name = "groupids")]
        public List<string> GroupIds { get; set; }
        /// <summary>
        /// 有效成员Id
        /// </summary>
        [Keyword(Name = "memberids")]
        public List<string> MemberIds { set; get; }
        /// <summary>
        /// 项目详情
        /// </summary>
        [Text(Name = "content", Analyzer = "ik_max_word", SearchAnalyzer = "ik_max_word")]
        public string Content { get; set; }

    }
}
