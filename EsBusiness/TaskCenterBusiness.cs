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
using EsEntity.TaskCenter.InnerModel;

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

        public ReturnResult SearchTasks(string currentAId, List<string> relationAId, string keyword, string projectId, bool isPaid, int pageIndex, int pageSize, DateTime? startTime, DateTime? endTime)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            QueryContainer qcAnd = Query<Task>.Bool(b => b.Must(m => m.Term(t => t.Field(f => f.IsDeleted == false && f.MemberIds.Contains(currentAId)))));
            if (projectId != "all")
            {
                qcAnd &= Query<Task>.Bool(b => b.Must(m => m.Term(t => t.Field(f => f.ProjectId == projectId))));
            }
            if (startTime.HasValue)
            {
                qcAnd &= Query<Task>.Bool(b => b.Must(m => m.Term(t => t.Field(f => f.StartTime >= startTime))));
            }
            if (endTime.HasValue)
            {
                qcAnd &= Query<Task>.Bool(b => b.Must(m => m.Term(t => t.Field(f => f.EndTime <= endTime))));
            }

            QueryContainer qcOr = Query<Task>.Bool(b => b.Must(s => s.MultiMatch(m => m.Fields(fs => fs
                    .Fields(
                        f => f.TaskName,
                        f => f.Keywords,
                        f => f.Discussions.First().Message,
                        f => f.Content)
                    )
                .Query(keyword))));
            if (relationAId != null && relationAId.Count > 0)
            {
                qcOr |= Query<Task>.Bool(b => b.Must(s => s.MultiMatch(m => m.Fields(fs => fs
                    .Fields(
                        f => f.Discussions.Any(o => o.MentionedAccountIds.Any(i => relationAId.Contains(i))),
                        f => relationAId.Contains(f.CreateAccountID),
                        f => f.MemberIds.Any(i => relationAId.Contains(i)))
                    )
                )));
            }
            if (isPaid)
            {
                qcOr |= Query<Task>.Bool(b => b.Must(s => s.MultiMatch(m => m.Fields(fs => fs.Fields(f => f.Attachments.First().AttContent)).Query(keyword))));
            }

            var result = client.Search<Task>(o => o
           .Source(source => source.Includes(include => include.Fields(field => field.CreateAccountID, field => field.TaskName, field => field.Content, field => field.ProjectId, field => field.CreateTime)))
           .Query(_ => qcAnd & qcOr)
               .From(pageIndex - 1)
               .Size(pageSize)
               .Highlight(hl => hl
                   .PreTags("<tag>")
                   .PostTags("</tag>")
                   .Fields(fs => fs
                       .Field(f => f.TaskName)
                       .Field(f => f.Content)
                   )
               )
               .Sort(sort => sort.Descending(task => task.CreateTime))
           );
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
                re.data = result.Documents;
            }
            return re;
        }

        public ReturnResult AddAttachmentsIntoTask(string taskId, List<EsEntity.TaskCenter.InnerModel.Attachment> list)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            //var result = client.UpdateByQuery<Task>(sq => sq.Query(q => q.Bool(b => b.Must(m => m.Ids(ids => ids.Values(taskId)))))
            //.Conflicts(Elasticsearch.Net.Conflicts.Proceed)
            //.Script(ExExtends<Task>.GetScriptInlineToAddFisrtElement(sp => sp.Attachments, list)
            // ));
            var result = client.Update<Task>(taskId, o => o.Script(ExExtends<Task>.GetScriptInlineToAddFisrtElement(sp => sp.Attachments, list)));
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }
        public ReturnResult RemoveAttachmentsInTask(string taskId, List<string> fileIds)
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
        public ReturnResult AddTaskDiscussion(string taskId, TaskDiscussion disc)
        {

            ReturnResult re = new ReturnResult(ResultCode.Error);
            //var result = client.UpdateByQuery<Task>(sq => sq.Query(q => q.Bool(b => b.Must(m => m.Ids(ids => ids.Values(taskId)))))
            //.Conflicts(Elasticsearch.Net.Conflicts.Proceed)
            //.Script(ExExtends<Task>.GetScriptInlineToAddFisrtElement(sp => sp.Discussions, new List<TaskDiscussion> { disc })
            // ));
            var result = client.Update<Task>(taskId, o => o.Script(ExExtends<Task>.GetScriptInlineToAddFisrtElement(sp => sp.Discussions, new List<TaskDiscussion> { disc })));
            if (result.IsValid)
            {
                re.code = ResultCode.Success;
            }
            return re;
        }
        public ReturnResult RemoveTaskDiscussion(string taskId, string discId)
        {
            ReturnResult re = new ReturnResult(ResultCode.Error);
            var bulkRequest = Helper.TaskCenterHelper.GetRemoveTaskAttsInArrayBulkRequest(taskId, new List<string> { discId });
            var result = client.Update<Task>(taskId, o => o.Script(ExExtends<Task>.GetScriptInlineToRemoveFisrtElementById(sc => sc.Discussions.First().DiscussionId, discId)));
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
            .Source(include => include.Includes(ics => ics.Fields(f => f.MemberIds)))
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
