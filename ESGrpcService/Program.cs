using Grpc.Core;
using System;
using Topshelf;

namespace ESGrpcService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ESSearchService>(s =>
                {
                    s.ConstructUsing(name => new ESSearchService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("明道讨论服务");
            });
        }
    }

    public class ESSearchService
    {
        private readonly string host = "0.0.0.0";//ConfigurationManager.AppSettings["Host"];
        private readonly string port = "9876";//ConfigurationManager.AppSettings["Port"];

        readonly Server server;
        public ESSearchService()
        {
            server = new Server
            {
                //Services = { MD.Discussion.DiscussionService.BindService(new serviceImpl()) },
                //Ports = { new ServerPort(host, Convert.ToInt32(port), ServerCredentials.Insecure) }
            };
    
        }

        public void Start() { server.Start(); }
        public void Stop() { server.ShutdownAsync(); }
    }

}
