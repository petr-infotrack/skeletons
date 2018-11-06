using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ApiNetCore.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace api_net_core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost webHost = BuildWebHost(args);

            webHost.Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseAppConfiguration()
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}
