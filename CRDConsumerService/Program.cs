using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Messaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRDConsumerService
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();



        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddSingleton<CRDService>();
            }
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.Use(async (context) =>
                {
                   await Task.Run(() => RedisMQService());
                });
            }
            public void RedisMQService()
            {
                List<int> list = new List<int> { 1, 2 };
                list.ForEach(o => System.Threading.Tasks.Task.Run(() => CRDService.Start(o)));
            }
        }


    }
}
