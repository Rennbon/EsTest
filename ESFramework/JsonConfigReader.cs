using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ESFramework
{
    /// <summary>
    /// 配置文件读取
    /// </summary>
    public class JsonConfigReader
    {
        public static IConfiguration Configuration => Get();
        public static IConfiguration Get()
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(),"..");
            IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("config.json")
                .Build();
            return Configuration;
        }
    }
}
