using ESFramework;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsEntity.TaskCenter
{
    [ElasticsearchType(Name = EsSysConfig.TypeNameFolderDiscussion, IdProperty = nameof(DiscussionId))]
    public class FolderDiscussion : InnerModel.DiscussionBase
    {
    }
}
