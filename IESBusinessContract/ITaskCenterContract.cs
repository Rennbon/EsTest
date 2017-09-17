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
        ReturnResult SearchTasks(string currentAId, List<string> relationAId, string keyword, string projectId, bool isPaid, int pageIndex, int pageSize, DateTime? startTime, DateTime? endTime);



        ReturnResult AddAttachmentsIntoTask(string taskId, List<EsEntity.TaskCenter.InnerModel.Attachment> list);

        ReturnResult RemoveAttachmentsInTask(string taskId, List<string> fileIds);

        ReturnResult AddTaskDiscussion(string taskId, TaskDiscussion disc);

        ReturnResult RemoveTaskDiscussion(string taskId, string discId);


        /// <summary>
        /// 单个任务修改指定字段
        /// </summary>
        /// <param name="methods"></param>
        /// <returns></returns>
        ReturnResult UpdateTasks(List<TaskMethed> methods);

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




        void CreateIndex();

    }
}
