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
using System.Linq.Expressions;

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

        /// <summary>
        /// 单个任务修改指定字段
        /// </summary>
        /// <param name="methods"></param>
        /// <returns></returns>
        public ReturnResult UpdateTasks(List<TaskMethed> methods)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var tidsNeedSearch = methods.Where(o => o.Methed == TaskMethodEnum.Pull_MemberIds || o.Methed == TaskMethodEnum.Push_MemberIds).Select(o => o.Task.TaskId).ToList();
            var tasks = client.GetMany<Task>(tidsNeedSearch).ToList().Select(o => o.Source);
            var bulkRequest = Helper.TaskCenterHelper.GetUpdateBulkRequest(methods, tasks);
            var result = client.Bulk(bulkRequest);
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }
        /// <summary>
        /// 批量新增任务
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public ReturnResult AddTasks(List<Task> tasks)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var result = client.IndexMany<Task>(tasks);
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }
        /// <summary>
        /// 批量删除任务
        /// </summary>
        /// <param name="taskIds">任务ids</param>
        /// <returns></returns>
        public ReturnResult RemoveTasks(List<string> taskIds)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var result = client.DeleteMany<Task>(taskIds.Select(o => new Task { TaskId = o }));
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }
        /// <summary>
        /// 批量删除任务
        /// </summary>
        /// <param name="folderId">项目id</param>
        /// <returns></returns>
        public ReturnResult RemoveTasks(string folderId)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var result = client.DeleteByQuery<Task>(o =>
                    o.Query(q =>
                        q.Term(m =>
                            m.Field(f =>
                                f.FolderID == folderId
                                )
                            )
                        )
                    );
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }

        public ReturnResult UpdateTasksFolderNameByFolderId()
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            return re;
        }
        public ReturnResult RemoveTasksFromFolder(string folderId)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);

            var obj = EntitySerializeExtends<Task>.DeserializeObjectToSet(new TypeFeild<Task>(o => o.MemberIds, new List<string> { "123" }), new TypeFeild<Task>(o => o.Keywords, new List<string> { "123" }));
            var result = client.UpdateByQuery<Task>(o => o
            .Query(q => q
                .Term(m => m
                    .Field(f => f
                        .FolderID == folderId
                        )
                    )
                )
            //.DocvalueFields(fd => fd.FolderID, fd => fd.FolderName, fd => fd.UpdateTime)
            .Script(script => script
                .Inline("ctx._source.fid ='';ctx._source.fname= '';")

            ));
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }



        public void CreateIndex()
        {

            if (!client.IndexExists(indexName).Exists)
            {
                var c = client.CreateIndex(indexName, i => i.UpdateAllTypes().Mappings(ms => ms
                   .Map<Task>(m => m.AutoMap())
                   .Map<TaskDiscussion>(m => m.AutoMap().Parent<Task>())
                   .Map<Folder>(m => m.AutoMap())
                   .Map<FolderDiscussion>(m => m.AutoMap().Parent<Folder>())));
            }
        }
    }
}
