using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ServiceStack.Messaging;
using System;
using System.Collections.Generic;

namespace CRDConsumerService
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisMQService();
        }

        public static void RedisMQService()
        {
            List<int> list = new List<int> { 1, 2 };
            list.ForEach(o =>System.Threading.Tasks.Task.Run(()=> CRDService.Start(o)));
        }
    }
}
