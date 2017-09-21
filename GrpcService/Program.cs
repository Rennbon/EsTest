using Elasticsearch;
using Grpc.Core;
using System;

namespace GrpcService
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskCenterService = ESService.BindService(new ESServiceImpl());

            int port = 0;
            string host = string.Empty;
            Server server = new Server
            {
                Services = {
                    taskCenterService
                },
                Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine($"Listening on port {port}");
            server.ShutdownTask.Wait();
        }
    }
}
