using System;
using EsBusiness;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TASKCENTER
            //TaskCenterBusiness.Instance.CreateIndex() ;
            #region addtask
            List<EsEntity.TaskCenter.Task> tasks = new List<EsEntity.TaskCenter.Task>();
            tasks.Add(new EsEntity.TaskCenter.Task
            {
                AppID = string.Empty,
                ChargeAccountId = "wo",
                CompleteTime = DateTime.Now,
                Content = "我是谁谁是我",
                CreateAccountID = "wo",
                CreateTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(30),
                FolderId = "f1",
                FolderName = "这是一个项目",
                IsDeleted = false,
                Keywords = new List<string> {
                    "123",
                    "",
                    "12321"
                },
                MemberIds = new List<string> {
                    "wo",
                    "ni",
                    "ta"
                },
                ParentId = string.Empty,
                ProjectId = string.Empty,
                StartTime = DateTime.Now.AddDays(-10),
                Status = 1,
                TaskId = "t1",
                TaskName = "测试任务1",
                UpdateTime = DateTime.Now,

            });
            tasks.Add(new EsEntity.TaskCenter.Task
            {
                AppID = string.Empty,
                ChargeAccountId = "wo",
                CompleteTime = DateTime.Now,
                Content = "我是谁谁是我",
                CreateAccountID = "wo",
                CreateTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(30),
                FolderId = "f1",
                FolderName = "这是一个项目",
                IsDeleted = false,
                Keywords = new List<string> {
                    "123",
                    "",
                    "12321"
                },
                MemberIds = new List<string> {
                    "wo",
                    "ni",
                    "ta"
                },
                ParentId = string.Empty,
                ProjectId = string.Empty,
                StartTime = DateTime.Now.AddDays(-10),
                Status = 1,
                TaskId = "t2",
                TaskName = "测试任务2",
                UpdateTime = DateTime.Now
            });
            //TaskCenterBusiness.Instance.AddTasks(tasks);
            #endregion addtask

            #region removetask
            //TaskCenterBusiness.Instance.RemoveTasks(new List<string> { "t1","t2"});
            #endregion removetask

            #region updateTask
            List<EsEntity.TaskCenterMethod.TaskMethed> metheds = new List<EsEntity.TaskCenterMethod.TaskMethed>();
            metheds.Add(new EsEntity.TaskCenterMethod.TaskMethed
            {
                Methed = EsEnum.TaskCenter.TaskMethodEnum.Set_TaskName,
                Task = new EsEntity.TaskCenter.Task
                {
                    TaskId = "t1",
                    TaskName = "任务名改11111"
                }
            });
            metheds.Add(new EsEntity.TaskCenterMethod.TaskMethed
            {
                Methed = EsEnum.TaskCenter.TaskMethodEnum.Push_MemberIds,
                Task = new EsEntity.TaskCenter.Task
                {
                    TaskId = "t2",
                    TaskName = "任务改22222",
                    MemberIds = new List<string> { "1", "3", "5" }
                }
            });
            //TaskCenterBusiness.Instance.UpdateTasks(metheds);
            #endregion updateTask
            TaskCenterBusiness.Instance.SSSS();

            //TaskCenterBusiness.Instance.UnlockFolderAndTasks("f1");
            #endregion TASKCENTER
            // EsBusiness.Test.Instance.CreateIndex();
            //EsBusiness.Test.Instance.AddTests(new List<EsEntity.Test.TestModel> { new EsEntity.Test.TestModel() {
            //    Id="test1",
            //    Name="测试1"

            //},new EsEntity.Test.TestModel{
            //    Id ="test2",
            //    Name="测试2"
            //} });
        }
    }
}
