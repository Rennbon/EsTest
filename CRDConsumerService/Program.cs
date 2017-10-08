using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Messaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using System.Threading;

namespace CRDConsumerService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("server start");
            List<int> list = new List<int> { 1, 2 };
            List<Task> tasks = new List<Task>();

            list.ForEach(o => tasks.Add(
                System.Threading.Tasks.Task.Run(() =>
                {
                    Console.WriteLine($"group{o} start");
                    CRDService.Start(o);         
                }
                )));

            Task.WaitAll(tasks.ToArray());


            //BuildWebHost(args).Run();
        }


        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .Build();



        //public class Startup
        //{
        //    public void ConfigureServices(IServiceCollection services)
        //    {
        //        services.AddSingleton<IServer, AA>();
        //    }
        //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //    {
        //    }

        //}
        //public class AA : IServer
        //{
        //    IFeatureCollection IServer.Features { get; }

        //    Task IServer.StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
        //    {
        //        Console.WriteLine("server start");
        //        var task = Task.Run(() => RedisMQService());
        //        Console.ReadLine();
        //        return task;
        //    }

        //    Task IServer.StopAsync(CancellationToken cancellationToken)
        //    {
        //        return Task.Run(() => Console.WriteLine("server stop"));
        //    }
        //    public void RedisMQService()
        //    {
        //        List<int> list = new List<int> { 1, 2 };
        //        list.ForEach(o => System.Threading.Tasks.Task.Run(() => CRDService.Start(o)));
        //    }

        //    #region IDisposable Support
        //    private bool disposedValue = false; // 要检测冗余调用

        //    protected virtual void Dispose(bool disposing)
        //    {
        //        if (!disposedValue)
        //        {
        //            if (disposing)
        //            {
        //                // TODO: 释放托管状态(托管对象)。
        //            }

        //            // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
        //            // TODO: 将大型字段设置为 null。

        //            disposedValue = true;
        //        }
        //    }

        //    // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        //    // ~AA() {
        //    //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //    //   Dispose(false);
        //    // }

        //    // 添加此代码以正确实现可处置模式。
        //    void IDisposable.Dispose()
        //    {
        //        // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //        Dispose(true);
        //        // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
        //        // GC.SuppressFinalize(this);
        //    }
        //    #endregion

        //}

    }
}
