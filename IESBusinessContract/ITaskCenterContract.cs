using EsEntity.TaskCenter;
using EsEntity.TaskCenter.InnerModel;
using EsEntity.TaskCenterMethod;
using ESFramework;
using System;
using System.Collections.Generic;

namespace IESBusinessContract
{
    public interface ITaskCenterContract : IContract
    {
        /// <summary>
        /// 查询任务
        /// </summary>
        /// <param name="currentAId"></param>
        /// <param name="relationAId"></param>
        /// <param name="keyword"></param>
        /// <param name="projectId"></param>
        /// <param name="isPaid"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        ReturnResult<List<Task>> SearchTasks(string currentAId, List<string> relationAId, string keyword, string projectId, bool isPaid, int pageIndex, int pageSize, DateTime? startTime, DateTime? endTime, string preTags, string postTags);
        /// <summary>
        /// 添加附件到任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        ReturnResult AddAttachmentsIntoTask(string taskId, List<EsEntity.TaskCenter.InnerModel.Attachment> list);
        /// <summary>
        /// 从任务中移除附件
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="fileIds"></param>
        /// <returns></returns>
        ReturnResult RemoveAttachmentsInTask(string taskId, List<string> fileIds);
        /// <summary>
        /// 添加任务讨论
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="discId"></param>
        /// <param name="message"></param>
        /// <param name="mentionedAIds"></param>
        /// <returns></returns>
        ReturnResult AddTaskDiscussion(string taskId, string discId, string message, List<string> mentionedAIds);
        /// <summary>
        /// 移除任务讨论
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="discId"></param>
        /// <returns></returns>
        ReturnResult RemoveTaskDiscussion(string taskId, string discId);
        /// <summary>
        /// 单个任务修改指定字段
        /// </summary>
        /// <param name="methods"></param>
        /// <returns></returns>
        ReturnResult UpdateTasks(List<TaskMethod> methods);
        /// <summary>
        /// 批量新增任务
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        ReturnResult AddTasks(List<Task> tasks);
        /// <summary>
        /// 批量删除任务
        /// </summary>
        /// <param name="taskIds">任务ids</param>
        /// <returns></returns>
        ReturnResult RemoveTasksByTaskIds(List<string> taskIds);
        /// <summary>
        /// 批量删除任务
        /// </summary>
        /// <param name="folderId">项目id</param>
        /// <returns></returns>
        ReturnResult RemoveTasksByFolderId(string folderId);
        /// <summary>
        /// 批量修改指定项目id的所有任务冗余项目名
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        ReturnResult UpdateTasksFolderNameByFolderId(string folderId, string folderName);
        /// <summary>
        /// 解锁项目下所有任务的关系(将指定项目下的所有任务中冗余的folderid和foldername清空)
        /// </summary>
        /// <param name="folderId"></param>
        /// <returns></returns>
        ReturnResult UnlockFolderAndTasks(string folderId);
        /// <summary>
        /// 创建索引
        /// </summary>
        void CreateIndex();

    }
}
