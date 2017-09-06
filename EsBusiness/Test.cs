using EsEntity.Test;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsBusiness
{
    public class Test : EsBase.EsDomain
    {
        public Test(string defaultIndexName, IEnumerable<string> urls) : base(defaultIndexName, urls)
        {
        }
        private static readonly Lazy<Test> lazy =
             new Lazy<Test>(() =>
             new Test("test", ESFramework.EsSysConfig.TaskCenterUrl));

        public static Test Instance
        {
            get { return lazy.Value; }
        }

        /// <summary>
        /// 批量新增任务
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public void AddTests(List<TestModel> ttt)
        {
            var result = client.IndexMany<TestModel>(ttt);
        }
        public void CreateIndex()
        {

            if (!client.IndexExists("Test").Exists)
            {
                var c = client.CreateIndex("test", i => i.UpdateAllTypes().Mappings(ms => ms
                   .Map<TestModel>(m => m.AutoMap())));

            }
        }
    }
}
