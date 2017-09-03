using System;
using System.Collections.Generic;
using System.Text;
using EsBusiness.EsBase;
using Nest;
using ESFramework;
using EsEntity.TaskCenter;
using System.Reflection;
using EsEntity;
using EsEntity.Indexer;
using System.Linq;
using EsEntity.TaskCenterMethod;
using EsEnum.TaskCenter;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ESFramework.Estensions;

namespace EsBusiness
{
    public class TaskCenterBusiness : EsBase.EsDomain
    {
        private static string indexName = ESFramework.EsSysConfig.IndexNameTaskCenter;
        private static IEnumerable<string> taskCenterUrl = ESFramework.EsSysConfig.TaskCenterUrl;
        private static Dictionary<Type, string> typeIndexDic = new Dictionary<Type, string> {
            {typeof(Task),indexName},
            {typeof(TaskDiscussion),indexName },
            {typeof(Folder),indexName },
            {typeof(FolderDiscussion),indexName },
        };
        public TaskCenterBusiness(Dictionary<Type, string> typeIndexDic, IEnumerable<string> urls) : base(typeIndexDic, urls)
        {
        }
        private static readonly Lazy<TaskCenterBusiness> lazy =
            new Lazy<TaskCenterBusiness>(() =>
            new TaskCenterBusiness(typeIndexDic, taskCenterUrl));

        public static TaskCenterBusiness Instance
        {
            get { return lazy.Value; }
        }


        public ReturnResult UpdateTasks(List<TaskMethed> metheds)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            BulkRequest bulkRequest = new BulkRequest() { Operations = new List<IBulkOperation>() };
            foreach (var item in metheds)
            {
                //var operation = new BulkUpdateOperation<Task,object>(item.Task.TaskID);

               // //operation.Doc = new {Name = item.Task.TaskName};
               // Task task = new Task { TaskName = "aaaaaaaaaaa" };
               // var operation = new BulkUpdateOperation<Task, string>(item.Task.TaskID).Doc= new ;

               // string jsonString = JsonConvert.SerializeObject(task, Formatting.Indented, new JsonSerializerSettings
               // {
               //     a
               //     ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
               //     ContractResolver = new CustomContractResolver(new List<string> {"TaskName"})
               // });
               //jsonString = client.Serializer.Serialize(async,)
                //operation.Doc =new JObject("Name","123");

             
                //bulkRequest.Operations.Add(operation);

            }
            var result = client.Bulk(bulkRequest);
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }

        public ReturnResult AddTasks(List<Task> tasks)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var result = client.IndexMany<Task>(tasks, indexName, "task");
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }

        public ReturnResult RemoveTasks(List<string> taskIds)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var result = client.DeleteMany<Task>(taskIds.Select(o => new Task { TaskID = o }));
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }

        public void CreateIndex()
        {

            if (!client.IndexExists("taskcenter").Exists)
            {
                var c = client.CreateIndex("taskcenter", i => i.UpdateAllTypes().Mappings(ms => ms
                   .Map<Task>(m => m.AutoMap())
                   .Map<TaskDiscussion>(m => m.AutoMap().Parent<Task>())
                   .Map<Folder>(m => m.AutoMap())
                   .Map<FolderDiscussion>(m => m.AutoMap().Parent<Folder>())));
            }
        }
    }
}
