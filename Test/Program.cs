using System;
using EsBusiness;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Interceptors;
using IESBusinessContract;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ITaskCenterContract client = InterceptIWindsor.Instance.Resolve<ITaskCenterContract>();
            //TaskCenterBusiness.Instance.CreateIndex();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


            var list = client.SearchTasks("ta", null, "中国人", "all", true, 0, 100, null, null);
            //string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.SSS");
            //IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            ////这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式  
            //timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            //string serialStr = JsonConvert.SerializeObject(DateTime.Now, Formatting.Indented, timeConverter);

            //TaskCenterBusiness.Instance.AddAttachmentIntoTask("t2", new List<string> { "yige kw", "还有kw", "无语了" });
            //TaskCenterBusiness.Instance.SearchTasks();
            //TaskCenterBusiness.Instance.RemoveAttachmentsInTask("t3", new List<string> { "10002", "10003", "10004" });

            //Parallel.For(5000, 6000, i =>
            //{
            //    //for (int i = 0; i < 5000; i++)
            //    //{
            //string name = "t3" ;
            //TaskCenterBusiness.Instance.AddAttachmentIntoTask(name, new List<EsEntity.TaskCenter.InnerModel.Attachment> { new EsEntity.TaskCenter.InnerModel.Attachment
            //        {
            //            FileId = DateTime.Now.Millisecond.ToString(),
            //            AttContent = GetRandomStr(30)
            //        },
            //        new EsEntity.TaskCenter.InnerModel.Attachment{
            //            FileId = DateTime.Now.Millisecond.ToString(),
            //            AttContent = GetRandomStr(30)
            //        }
            //});
            //    //}
            //});

            //TaskCenterBusiness.Instance.SSSS();



            #region TASKCENTER
            //TaskCenterBusiness.Instance.CreateIndex();
            return;
            #region addtask
            List<EsEntity.TaskCenter.Task> tasks = new List<EsEntity.TaskCenter.Task>() {
                new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "wo",
                    CompleteTime = DateTime.Now,
                    Content = "今天要拿fist blood",
                    CreateAccountID = "wo",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(20),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "1血好拿吗",
                            "太白菜大神已经无人可挡了",
                            "下班去撸串"
                        },
                    MemberIds = new List<string> {
                            "wo",
                            "ta"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-10),
                    Status = 1,
                    TaskId = "t2",//$"t{count}",
                    TaskName ="dota集锦", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="一直都有一座补课跨越的山阻拦着",
                            FileId ="3"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="无语的很，真是无话可说呢",
                            FileId="4"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "呼叫呼叫"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "你个垃圾会不会玩"
                        }

                    }
                },new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "ni",
                    CompleteTime = DateTime.Now,
                    Content = "关二哥脸好红，一定是看黄书了",
                    CreateAccountID = "ni",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "青龙偃月刀",
                            "刀削面呵呵呵",
                            "身份证：310228102401011506"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "wo"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t3",//$"t{count}",
                    TaskName ="武圣白起变二哥了", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="三国战纪飞龙在天，秋风扫落叶",
                            FileId ="5"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="赤兔马和貂蝉的接锅侠",
                            FileId="6"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "二嫂为什么要跳井"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "大哥就是我的天"
                        }

                    }
                },new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "ni",
                    CompleteTime = DateTime.Now,
                    Content = "发哥附身,逢赌必胜",
                    CreateAccountID = "ni",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "搓个A",
                            "showhand,要发达了",
                            "带你牛逼带你飞"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "ta"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t4",//$"t{count}",
                    TaskName ="赌神归来", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="背景是如此的令人着迷",
                            FileId ="7"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="巧克力是德芙的还是好时的还是费列罗",
                            FileId="8"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "今晚实现一个小目标"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "一分钟几百万上下"
                        }

                    }
                },new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "ta",
                    CompleteTime = DateTime.Now,
                    Content = "周星星的功夫到底拍的如何",
                    CreateAccountID = "ta",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "如来神掌",
                            "蛤蟆功",
                            "斧头帮dancing"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "ta",
                            "wo"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t5",//$"t{count}",
                    TaskName ="星爷归来", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="哈哈哈哈哈哈啊哈",
                            FileId ="9"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="我对您的敬仰犹如滔滔江水连绵不绝，又犹如黄河泛滥一发而不可收拾",
                            FileId="10"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "你是最棒滴，你知道吗"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "曾今有一份真诚的爱放在我面前，我没去珍惜，等到失去的时候我才追悔莫及，如果上天再给我重来一次的机会，我会说，打劫！！！"
                        }

                    }
                },new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "ta",
                    CompleteTime = DateTime.Now,
                    Content = "github 代码管理方案",
                    CreateAccountID = "ta",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "git shell",
                            "csharp",
                            "sql server"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "ta",
                            "wo"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t6",//$"t{count}",
                    TaskName ="微软ide及其他", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="c#好牛逼",
                            FileId ="11"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="宇宙第一ide",
                            FileId="12"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "开源太晚了，好可惜，不然java就是坨屎"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "c#何去何从"
                        }

                    }
                }
                ,new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "ta",
                    CompleteTime = DateTime.Now,
                    Content = "太白菜大神的流水账",
                    CreateAccountID = "ta",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "git shell",
                            "csharp",
                            "sql server"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "ta",
                            "wo"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t7",//$"t{count}",
                    TaskName ="God Rennbon", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="测试语句快累死我了",
                            FileId ="13"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="哭啊哭",
                            FileId="14"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "Elasticsearch 开发方案"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "Mongodb数据迁移"
                        }

                    }
                },new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "wo",
                    CompleteTime = DateTime.Now,
                    Content = "测试插到死，数据啊数据",
                    CreateAccountID = "ni",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "假数据1",
                            "假数据2",
                            "假数据3"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "wo"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t8",//$"t{count}",
                    TaskName ="一切都是为了测试", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="测试语句快累死我了",
                            FileId ="15"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="for while foreach swtich",
                            FileId="16"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "看星星一步两步三步四步望着天"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "南瓜马车的午夜"
                        }

                    }
                },new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "ta",
                    CompleteTime = DateTime.Now,
                    Content = "老本很坚固了，不会爆的",
                    CreateAccountID = "ta",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "坦克大战",
                            "魂斗罗",
                            "双截龙"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "ta",
                            "wo"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t9",//$"t{count}",
                    TaskName ="FC 游戏集锦", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="你的蘑菇好厉害",
                            FileId ="17"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="公主去哪里了",
                            FileId="18"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "超级马里奥"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "马里奥拔萝卜"
                        }

                    }
                },new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "ta",
                    CompleteTime = DateTime.Now,
                    Content = "回收孔调，电脑，电冰箱",
                    CreateAccountID = "ta",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "破烂",
                            "回收",
                            "我的命好苦"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "ta",
                            "wo"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t10",//$"t{count}",
                    TaskName ="加点回收", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="回收女朋友，老婆，二奶",
                            FileId ="1300"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="一斤20块",
                            FileId="1400"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "回收家族的奋斗史"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "bang you nong bing xiang ma wa"
                        }

                    }
                }
                ,new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "ta",
                    CompleteTime = DateTime.Now,
                    Content = "高富帅，土肥圆，白富美，穷挫矮",
                    CreateAccountID = "ta",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "官二代",
                            "星二代",
                            "拆二代"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "ta",
                            "wo"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t11",//$"t{count}",
                    TaskName ="如何成为高富帅", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="穷则独善其身，富则妻妾成群",
                            FileId ="13000"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="韦小宝附体",
                            FileId="14000"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "康熙擒鳌拜"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "弯弓射大雕"
                        }

                    }
                },new EsEntity.TaskCenter.Task
                {
                    AppId = string.Empty,
                    ChargeAccountId = "ta",
                    CompleteTime = DateTime.Now,
                    Content = "别人休假我加班，保险自己缴，房贷没资格，幸好不用付停车费，因为我根本没有车",
                    CreateAccountID = "ta",
                    CreateTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(28),
                    FolderId = "f1",
                    FolderName = "这是一个项目",
                    IsDeleted = false,
                    Keywords = new List<string> {
                            "money money moeny",
                            "让我中一次彩票吧",
                            "让我继承一个不认识的远房亲戚的海量遗产吧"
                        },
                    MemberIds = new List<string> {
                            "ni",
                            "ta",
                            "wo"
                        },
                    ParentId = string.Empty,
                    ProjectId = string.Empty,
                    StartTime = DateTime.Now.AddDays(-12),
                    Status = 1,
                    TaskId = "t12",//$"t{count}",
                    TaskName ="做梦都想钱", //$"测试任务{count}",
                    UpdateTime = DateTime.Now,
                    Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> {
                        new EsEntity.TaskCenter.InnerModel.Attachment {
                            AttContent="加油加油加油，嘿嘿嘿",
                            FileId ="20"
                        },new EsEntity.TaskCenter.InnerModel.Attachment{
                            AttContent ="努力努力努力，呀呀呀",
                            FileId="21"
                        }
                    },
                    Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "奋斗奋斗奋斗卖保险"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "奋斗奋斗奋斗卖期货"
                        }

                    }
                }
            };
            int count = 1000;
            //for (int p = 0; p < 20; p++)
            //{
            count++;
            var task = new EsEntity.TaskCenter.Task
            {
                AppId = string.Empty,
                ChargeAccountId = "wo",
                CompleteTime = DateTime.Now,
                Content = "今天是个好日子",
                CreateAccountID = "wo",
                CreateTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(30),
                FolderId = "f1",
                FolderName = "这是一个项目",
                IsDeleted = false,
                Keywords = new List<string> {
                            "1.5元",
                            "中国/上海",
                            "风景很好"
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
                TaskId = "t1",//$"t{count}",
                TaskName = "不可能完成的任务", //$"测试任务{count}",
                UpdateTime = DateTime.Now,

                Discussions = new List<EsEntity.TaskCenter.InnerModel.TaskDiscussion>{
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion{
                            DiscussionId="1",
                            MentionedAccountIds=new List<string>(),
                            Message = "蛋定"
                        },
                        new EsEntity.TaskCenter.InnerModel.TaskDiscussion
                        {
                            DiscussionId="2",
                            MentionedAccountIds=new List<string>(),
                            Message = "你妹啊"
                        }

                    }
            };
            task.Attachments = new List<EsEntity.TaskCenter.InnerModel.Attachment> { new EsEntity.TaskCenter.InnerModel.Attachment {
                    AttContent="呵呵呵，我就笑笑不说话",
                    FileId ="1"
                },new EsEntity.TaskCenter.InnerModel.Attachment{
                    AttContent ="SF五杀，已经无人可当了",
                    FileId="2"
                }
                };
            //for (var n = 0; n < 150; n++)
            //{
            //Parallel.For(1, 100, n =>
            //{
            //    EsEntity.TaskCenter.InnerModel.Attachment att = new EsEntity.TaskCenter.InnerModel.Attachment
            //    {
            //        FileId = DateTime.Now.Millisecond.ToString(),
            //        AttContent = GetRandomStr(300)
            //    };
            //    task.Attachments.Add(att);
            //});
            tasks.Add(task);


            //TaskCenterBusiness.Instance.AddTasks(tasks);
            //}

            #endregion addtask
            return;
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
                sb.Append(GetRandomChinese(new Random().Next(10, 200)) + ",");
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
                int index = i;
                if (index > bytes.Length)
                {
                    index = bytes.Length - 1;
                }
                string temp = gb.GetString((byte[])Convert.ChangeType(bytes[index], typeof(byte[])));
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
