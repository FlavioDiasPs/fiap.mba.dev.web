using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Fiap.StackOverflow.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args);
        }
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
        }
    }
}
