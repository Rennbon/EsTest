using EsEntity.TaskCenterMethod;
using ESFramework;
using Grpc.Core;
using IESBusinessContract;
using Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Elasticsearch.ESService;

namespace GrpcService
{
    public class ESServiceImpl : ESServiceBase
    {
        private readonly ITaskCenterContract taskCenterService;
        public ESServiceImpl()
        {
            taskCenterService = InterceptIWindsor.Instance.Resolve<ITaskCenterContract>();
        }
        /// <summary>
        ///*
        ///发送讨论
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.SearchTasksResult> SearchTasks(Elasticsearch.SearchTasksRequest request, ServerCallContext context)
        {
            DateTime? startTime = null;
            if (request.StartTime != 0)
            {
                startTime = DateTime.FromBinary(request.StartTime);
            }
            DateTime? endTime = null;
            if (request.EndTime != 0)
            {
                endTime = DateTime.FromBinary(request.EndTime);
            }
            var response = taskCenterService.SearchTasks(request.CurrentAId, request.RelationAIds.ToList(), request.Keyword, request.ProjectId, request.IsPaid, request.PageIndex, request.PageSize, startTime, endTime, request.PreTags, request.PostTags);
            Elasticsearch.SearchTasksResult result = new Elasticsearch.SearchTasksResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            if (response.code == ResultCode.Success)
            {
                result.Tasks.AddRange(response.data.Select(o => new Elasticsearch.TaskDto
                {
                    CreateAid = o.CreateAccountId,
                    Content = o.Content,
                    CreateTime = o.CreateTime.ToBinary(),
                    ProjectId = o.ProjectId,
                    TaskId = o.TaskId,
                    TaskName = o.TaskName
                }));
            }
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///添加附件
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> AddAttachmentsIntoTask(Elasticsearch.AddAttachmentsIntoTaskRequest request, ServerCallContext context)
        {
            List<EsEntity.TaskCenter.InnerModel.Attachment> atts = request.Atts.Select(o => new EsEntity.TaskCenter.InnerModel.Attachment
            {
                FileId = o.FileId,
                AttContent = o.Content
            }).ToList();
            var response = taskCenterService.AddAttachmentsIntoTask(
                request.TaskId,
                atts);
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///删除附件
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> RemoveAttachmentsInTask(Elasticsearch.RemoveAttachmentsInTaskRequest request, ServerCallContext context)
        {
            var response = taskCenterService.RemoveAttachmentsInTask(request.TaskId, request.FileIds.ToList());
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///添加讨论
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> AddTaskDiscussionInTask(Elasticsearch.AddTaskDiscussionInTaskRequest request, ServerCallContext context)
        {
            var response = taskCenterService.AddTaskDiscussion(request.TaskId, request.DiscId, request.Message, request.MentionedAIds.ToList());
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///删除讨论
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> RemoveTaskDiscussion(Elasticsearch.RemoveTaskDiscussionRequest request, ServerCallContext context)
        {
            var response = taskCenterService.RemoveTaskDiscussion(request.TaskId, request.DiscId);
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///修改任务
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> UpdateTasks(Elasticsearch.UpdateTasksRequest request, ServerCallContext context)
        {
            List<TaskMethod> methods = request.Methods.Select(o => new TaskMethod {
                Method = (EsEnum.TaskCenter.TaskMethodEnum)o.Method,
                Task = new EsEntity.TaskCenter.Task {
                    TaskId = o.Task.TaskId,
                    TaskName = o.Task.TaskName,
                    AppId = o.Task.AppId,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment>(),
                    ChargeAccountId = o.Task.ChargeAId,
                    CreateAccountId = o.Task.CreateAId,
                    CompleteTime = DateTime.FromBinary(o.Task.CompleteTime),
                    Content = o.Task.Content,
                    CreateTime = DateTime.FromBinary(o.Task.CreateTime),
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>(),
                    EndTime = DateTime.FromBinary(o.Task.EndTime),
                    FolderId = o.Task.FolderId,
                    FolderName = o.Task.FolderName,
                    IsDeleted = o.Task.IsDeleted,
                    Keywords = o.Task.Keywords.ToList(),
                    MemberIds = o.Task.MemberIds.ToList(),
                    ParentId = o.Task.ParentId,
                    ProjectId = o.Task.ProjectId,
                    StartTime = DateTime.FromBinary(o.Task.StartTime),
                    Status = o.Task.Status,               
                    UpdateTime = DateTime.FromBinary(o.Task.UpdateTime)
                }
            }).ToList();  
            var response = taskCenterService.UpdateTasks(methods);
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///批量增加任务
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> AddTasks(Elasticsearch.AddTasksRequest request, ServerCallContext context)
        {
            List<EsEntity.TaskCenter.Task> tasks = request.Tasks.Select(o => new EsEntity.TaskCenter.Task
            {
                TaskId = o.TaskId,
                TaskName = o.TaskName,
                AppId = o.AppId,
                Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment>(),
                ChargeAccountId = o.ChargeAId,
                CreateAccountId = o.CreateAId,
                CompleteTime = DateTime.FromBinary(o.CompleteTime),
                Content = o.Content,
                CreateTime = DateTime.FromBinary(o.CreateTime),
                Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>(),
                EndTime = DateTime.FromBinary(o.EndTime),
                FolderId = o.FolderId,
                FolderName = o.FolderName,
                IsDeleted = o.IsDeleted,
                Keywords = o.Keywords.ToList(),
                MemberIds = o.MemberIds.ToList(),
                ParentId = o.ParentId,
                ProjectId = o.ProjectId,
                StartTime = DateTime.FromBinary(o.StartTime),
                Status = o.Status,
                UpdateTime = DateTime.FromBinary(o.UpdateTime)

            }).ToList();
            var response = taskCenterService.AddTasks(tasks);
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///批量根据任务id伪删除任务
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> RemoveTasksByTaskIds(Elasticsearch.RemoveTasksByTaskIdsRequest request, ServerCallContext context)
        {
            var response = taskCenterService.RemoveTasksByTaskIds(request.TaskIds.ToList());
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///批量根据项目id伪删除任务
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> RemoveTasksByFolderId(Elasticsearch.RemoveTasksByFolderIdRequest request, ServerCallContext context)
        {
            var response = taskCenterService.RemoveTasksByFolderId(request.FolderId);
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///批量修改指定项目id的所有任务冗余项目名
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> UpdateTasksFolderNameByFolderId(Elasticsearch.UpdateTasksFolderNameByFolderIdRequest request, ServerCallContext context)
        {
            var response = taskCenterService.UpdateTasksFolderNameByFolderId(request.FolderId, request.FolderName);
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }

        /// <summary>
        ///*
        ///解锁项目下所有任务的关系(将指定项目下的所有任务中冗余的folderid和foldername清空)
        /// </summary>
        /// <param name="request">The request received from the client.</param>
        /// <param name="context">The context of the server-side call handler being invoked.</param>
        /// <returns>The response to send back to the client (wrapped by a task).</returns>
        public override Task<Elasticsearch.ExecuteResult> UnlockFolderAndTasks(Elasticsearch.UnlockFolderAndTasksRequest request, ServerCallContext context)
        {

            var response = taskCenterService.UnlockFolderAndTasks(request.FolderId);
            Elasticsearch.ExecuteResult result = new Elasticsearch.ExecuteResult()
            {
                Code = (int)response.code,
                Msg = Common.GetEnumDesc<ResultCode>(response.code)
            };
            return Task.FromResult(result);
        }
    }

}