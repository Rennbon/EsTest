using ESFramework;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsEntity.TaskCenter
{
    [ElasticsearchType(Name = EsSysConfig.TypeNameTaskDiscussion, IdProperty = nameof(DiscussionId))]
    public class TaskDiscussion : InnerModel.DiscussionBase
    {

    }

}
