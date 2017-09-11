using System;
using EsBusiness;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskCenterBusiness.Instance.CreateIndex();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.SSS");
            //IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            ////这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式  
            //timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            //string serialStr = JsonConvert.SerializeObject(DateTime.Now, Formatting.Indented, timeConverter);

            //TaskCenterBusiness.Instance.AddAttachmentIntoTask("t2", new List<string> { "yige kw", "还有kw", "无语了" });

            Parallel.For(1, 5000, i =>
            {
                //for (int i = 0; i < 5000; i++)
                //{
                string name = "t" + new Random(DateTime.Now.Millisecond).Next(3, 20);
                TaskCenterBusiness.Instance.AddAttachmentIntoTask(name, new List<EsEntity.TaskCenter.InnerModel.Attachment> { new EsEntity.TaskCenter.InnerModel.Attachment
                    {
                        FileId = DateTime.Now.Millisecond.ToString(),
                        AttContent = GetRandomStr(30)
                    }
            });
                //}
            });

            TaskCenterBusiness.Instance.SSSS();

            return;

            #region TASKCENTER
            //TaskCenterBusiness.Instance.CreateIndex();
            //return;
            #region addtask
            List<EsEntity.TaskCenter.Task> tasks = new List<EsEntity.TaskCenter.Task>();
            int count = 0;
            for (int p = 0; p < 3; p++)
            {
                count++;
                var task = new EsEntity.TaskCenter.Task
                {
                    AppID = string.Empty,
                    ChargeAccountId = "wo",
                    CompleteTime = DateTime.Now,
                    Content = "123123123",
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
                    TaskId = $"t{count}",
                    TaskName = $"测试任务{count}",
                    UpdateTime = DateTime.Now,

                };
                task.Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> { };
                //for (var n = 0; n < 150; n++)
                //{
                Parallel.For(1, 100, n =>
                {
                    EsEntity.TaskCenter.InnerModel.Attachment att = new EsEntity.TaskCenter.InnerModel.Attachment
                    {
                        FileId = DateTime.Now.Millisecond.ToString(),
                        AttContent = GetRandomStr(30)
                    };
                    task.Attachments.Add(att);
                });
                tasks.Add(task);
                TaskCenterBusiness.Instance.AddTasks(tasks);
            }

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
            //TaskCenterBusiness.Instance.SSSS();

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

        public static string GetRandomStr(int count)
        {
            StringBuilder sb = new StringBuilder();

            Parallel.For(1, count, i =>
            {
                sb.Append(GetRandomChinese(new Random().Next(10, 2000)) + ",");
            });
            return sb.ToString();
        }

        public static string GetRandomChinese(int strlength)
        {
            // 获取GB2312编码页（表）   
            Encoding gb = Encoding.GetEncoding("GB2312");

            object[] bytes = CreateRegionCode(strlength);

            StringBuilder sb = new StringBuilder();

            Parallel.For(1, strlength, i =>
            {
                string temp = gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));
                sb.Append(temp);
            });

            return sb.ToString();
        }

        /**  
此函数在汉字编码范围内随机创建含两个元素的十六进制字节数组，每个字节数组代表一个汉字，并将  
四个字节数组存储在object数组中。  
参数：strlength，代表需要产生的汉字个数  
        **/
        private static object[] CreateRegionCode(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素   
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

            Random rnd = new Random();

            //定义一个object数组用来   
            object[] bytes = new object[strlength];

            /** 
             每循环一次产生一个含两个元素的十六进制字节数组，并将其放入bytes数组中  
             每个汉字有四个区位码组成  
             区位码第1位和区位码第2位作为字节数组第一个元素  
             区位码第3位和区位码第4位作为字节数组第二个元素  
            **/
            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位   
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();

                //区位码第2位   
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i); // 更换随机数发生器的 种子避免产生重复值   
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                //区位码第3位   
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();

                //区位码第4位   
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();

                // 定义两个字节变量存储产生的随机汉字区位码   
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                // 将两个字节变量存储在字节数组中   
                byte[] str_r = new byte[] { byte1, byte2 };

                // 将产生的一个汉字的字节数组放入object数组中   
                bytes.SetValue(str_r, i);
            }

            return bytes;
        }
    }
}
