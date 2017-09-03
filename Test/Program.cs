using System;
using EsBusiness;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskCenterBusiness.Instance.CreateIndex() ;
            #region addtask
            List<EsEntity.TaskCenter.Task> tasks = new List<EsEntity.TaskCenter.Task>();
            tasks.Add(new EsEntity.TaskCenter.Task
            {
                AppID = string.Empty,
                ChargeAccountID = "wo",
                CompleteTime = DateTime.Now,
                Content = "我是谁谁是我",
                CreateAccountID = "wo",
                CreateTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(30),
                FolderID = "f1",
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
                ParentID = string.Empty,
                ProjectId = string.Empty,
                StartTime = DateTime.Now.AddDays(-10),
                Status = 1,
                TaskID = "t1",
                TaskName = "测试任务1",
                UpdateTime = DateTime.Now,

            });
            tasks.Add(new EsEntity.TaskCenter.Task
            {
                AppID = string.Empty,
                ChargeAccountID = "wo",
                CompleteTime = DateTime.Now,
                Content = "我是谁谁是我",
                CreateAccountID = "wo",
                CreateTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(30),
                FolderID = "f1",
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
                ParentID = string.Empty,
                ProjectId = string.Empty,
                StartTime = DateTime.Now.AddDays(-10),
                Status = 1,
                TaskID = "t2",
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
                    TaskID = "t1",
                    TaskName = "任务名改11111"
                }
            });
            metheds.Add(new EsEntity.TaskCenterMethod.TaskMethed
            {
                Methed = EsEnum.TaskCenter.TaskMethodEnum.Set_TaskName,
                Task = new EsEntity.TaskCenter.Task
                {
                    TaskID = "t2",
                    TaskName = "任务改22222"
                }
            });
            TaskCenterBusiness.Instance.UpdateTasks(metheds);
            #endregion updateTask

        }
    }
}
