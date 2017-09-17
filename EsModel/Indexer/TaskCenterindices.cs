using System;
using System.Collections.Generic;
using System.Text;
using Nest;
using EsEntity.TaskCenter;
using ESFramework;

namespace EsEntity.Indexer
{
    public static class TaskCenterindices
    {

        public static Func<CreateIndexDescriptor, ICreateIndexRequest> TaskMappingSelector = i => i.Mappings(ms => ms.Map<Task>(m => m.AutoMap()));



        public static Func<CreateIndexDescriptor, ICreateIndexRequest> FolderMappingSelector = i => i.Mappings(ms => ms.Map<Folder>(m => m.AutoMap()));


        public static CreateIndexDescriptor TaskCentnerMappingSelector = new CreateIndexDescriptor(EsSysConfig.IndexNameTaskCenter)
        .Mappings(ms => ms
            .Map<Task>(m => m.AutoMap())
        );
    }
}
