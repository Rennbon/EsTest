using System;
using System.Collections.Generic;
using System.Text;
using EsEntity.TaskCenterMethod;
using EsEntity.TaskCenter;
using Nest;
using ESFramework.Estensions;
using System.Linq;

namespace EsBusiness.Helper
{
    /// <summary>
    /// 不允许在这里做增删改查操作，只能辅助
    /// </summary>
    public class TaskCenterHelper
    {
        public static BulkRequest GetUpdateBulkRequest(List<TaskMethed> methods, IEnumerable<Task> tasks)
        {
            BulkRequest bulkRequest = new BulkRequest() { Operations = new List<IBulkOperation>() };
            foreach (var item in methods)
            {
                var operation = new BulkUpdateOperation<Task, object>(item.Task.TaskId);
                switch (item.Methed)
                {
                    case EsEnum.TaskCenter.TaskMethodEnum.Pull_MemberIds:
                        var pullMemberIds = GetMemberIds(tasks, item.Task.TaskId).Except(item.Task.MemberIds).ToList();
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.MemberIds, pullMemberIds);      
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Push_MemberIds:
                        var pushMemberIds = GetMemberIds(tasks, item.Task.TaskId);
                        pushMemberIds.AddRange(item.Task.MemberIds);
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.MemberIds, pushMemberIds.Distinct().ToList());
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_Charge:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.ChargeAccountId, item.Task.ChargeAccountId);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_CompleteTime:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.CompleteTime, item.Task.CompleteTime);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_Content:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.Content, item.Task.Content);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_CreateAccountId:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.CreateAccountID, item.Task.CreateAccountID);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_EndTime:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.EndTime, item.Task.EndTime);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_FolderId:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.FolderId, item.Task.FolderId);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_FolderName:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.FolderName, item.Task.FolderName);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_Keywords:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.Keywords, item.Task.Keywords);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_ParentId:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.ParentId, item.Task.ParentId);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_StartTime:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.StartTime, item.Task.StartTime);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_Status:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.Status, item.Task.Status);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_TaskName:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.TaskName, item.Task.TaskName);
                        break;
                    case EsEnum.TaskCenter.TaskMethodEnum.Set_UpdateTime:
                        operation.Doc = GlobalHelper<Task>.DeserializeObjectToSet(o => o.UpdateTime, item.Task.UpdateTime);             
                        break;
                    default: break;
                }
                bulkRequest.Operations.Add(operation);
            }
            return bulkRequest;
        }

        private static List<string> GetMemberIds(IEnumerable<Task> tasks, string taskId)
        {
            var task = tasks.FirstOrDefault(o => o.TaskId == taskId);
            if (task == null)
                return new List<string>();
            return task.MemberIds;
        }
    }
}
