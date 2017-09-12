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
        public TaskCenterBusiness(string defaultIndexName, IEnumerable<string> urls) : base(defaultIndexName, urls)
        {
        }
        private static readonly Lazy<TaskCenterBusiness> lazy =
            new Lazy<TaskCenterBusiness>(() =>
            new TaskCenterBusiness(indexName, taskCenterUrl));

        public static TaskCenterBusiness Instance
        {
            get { return lazy.Value; }
        }
        public void SSSS()
        {
            var aaa = client.Search<Task>(sq => sq.Source(include => include.Includes(ics => ics.Fields(f => f.Attachments))));
            //var result = client.MultiSearch(ms => ms
            //     .Search<Task>(indexName, o => o.Index(indexName).Query(q => q.Term(t => t.Field(f => f.TaskId == "t1"))))
            //     .Search<EsEntity.Test.TestModel>("test", o => o.Index("test").Query(q => q.Term(t => t.Field(f => f.Id == "test2"))))
            //     );
        }

        public ReturnResult SearchTasks()
        {
            return null;
         
        }

        public ReturnResult AddAttachmentIntoTask(string taskId, List<string> list)
        {

            //var ccc = client.Search<Task>(sq => sq.Query(q => q.Bool(b => b.Must(m => m.Ids(ids => ids.Values(taskId))))));
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var result = client.UpdateByQuery<Task>(sq => sq.Query(q => q.Bool(b => b.Must(m => m.Ids(ids => ids.Values(taskId)))))
            .Conflicts(Elasticsearch.Net.Conflicts.Proceed)
            .Script(ExExtends<Task>.GetScriptInlineToAddFisrtElement(sp => sp.Keywords, list))
             );
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }
        public ReturnResult AddAttachmentIntoTask(string taskId, List<EsEntity.TaskCenter.InnerModel.Attachment> list)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            int strlength = list.First().AttContent.Length;
            var t1 = DateTime.Now;
            var result = client.UpdateByQuery<Task>(sq => sq.Query(q => q.Bool(b => b.Must(m => m.Ids(ids => ids.Values(taskId)))))
            .Conflicts(Elasticsearch.Net.Conflicts.Proceed)
            .Script(ExExtends<Task>.GetScriptInlineToAddFisrtElement(sp => sp.Attachments, list)
             ));
            var t2 = DateTime.Now;
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            ESFramework.Log.WriteLoacl.WriteFile($"taskid:{taskId};result:{result.IsValid},time-consuming:{(t2 - t1).TotalMilliseconds},length:{strlength}", "es/log1.txt");
            return re;
        }
        public ReturnResult RemoveTaskAttsInArray(string taskId, List<string> fileIds)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var bulkRequest = Helper.TaskCenterHelper.GetRemoveTaskAttsInArrayBulkRequest(taskId, fileIds);
            var result = client.Bulk(bulkRequest);
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
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
            //var tasks = client.GetMany<Task>(tidsNeedSearch).ToList().Select(o => o.Source);
            var tasks = client.Search<Task>(sq => sq
            .Source(include => include.Includes(ics => ics.Fields(f => f.Attachments)))
            .Query(q => q.Term(t => t.Field(f => tidsNeedSearch.Contains(f.TaskId))))
            ).Documents;
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
            var t1 = DateTime.Now;
            var result = client.IndexMany<Task>(tasks);
            var t2 = DateTime.Now;
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            ESFramework.Log.WriteLoacl.WriteFile($"result:{result.IsValid},time-consuming:{(t2 - t1).TotalMilliseconds}", "es/addtask.txt");
            return re;
        }
        /// <summary>
        /// 批量删除任务
        /// </summary>
        /// <param name="taskIds">任务ids</param>
        /// <returns></returns>
        public ReturnResult RemoveTasksByTaskIds(List<string> taskIds)
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
        public ReturnResult RemoveTasksByFolderId(string folderId)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var result = client.UpdateByQuery<Task>(o => o
            .Query(q => q
               .Term(m => m
                   .Field(f => f
                       .FolderId == folderId
                       )
                   )
               )
           .Conflicts(Elasticsearch.Net.Conflicts.Proceed)
           .Script(script => script
                .Inline(ExExtends<Task>.GetScriptInlineToSet("ctx._source", new TypeFeild<Task>(tf => tf.IsDeleted, true))
            )));
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }
        /// <summary>
        /// 批量修改指定项目id的所有任务冗余项目名
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public ReturnResult UpdateTasksFolderNameByFolderId(string folderId, string folderName)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var result = client.UpdateByQuery<Task>(o => o
            .Query(q => q
               .Term(m => m
                   .Field(f => f
                       .FolderId == folderId
                       )
                   )
               )
           .Conflicts(Elasticsearch.Net.Conflicts.Proceed)
           .Script(script => script
                .Inline(ExExtends<Task>.GetScriptInlineToSet("ctx._source", new TypeFeild<Task>(tf => tf.FolderName, folderName))
            )));
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }



        /// <summary>
        /// 解锁项目下所有任务的关系(将指定项目下的所有任务中冗余的folderid和foldername清空)
        /// </summary>
        /// <param name="folderId"></param>
        /// <returns></returns>
        public ReturnResult UnlockFolderAndTasks(string folderId)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var result = client.UpdateByQuery<Task>(o => o
            .Query(q => q
                .Term(m => m
                    .Field(f => f
                        .FolderId == folderId
                        )
                    )
                )
            .Conflicts(Elasticsearch.Net.Conflicts.Proceed)
            .Script(script => script
                .Inline(ExExtends<Task>.GetScriptInlineToSet("ctx._source", new TypeFeild<Task>(tf => tf.FolderId, string.Empty), new TypeFeild<Task>(tf => tf.FolderName, string.Empty))
            )));
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
                   .Map<Task>(m => m.AutoMap())));
            }
        }
    }
}
