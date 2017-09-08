using ESFramework;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsEntity.TaskCenter
{
    /// <summary>
    /// 任务讨论
    /// </summary>
    [ElasticsearchType(Name = EsSysConfig.TypeNameTaskDiscussion, IdProperty = nameof(DiscussionId))]
    [Serializable]
    public class TaskDiscussion : InnerModel.DiscussionBase
    {
        
    }

}
