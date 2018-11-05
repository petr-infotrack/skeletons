using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;


namespace ApiNetCore.Configuration
{
    public static class SettingsConfiguration
    {
        public static IWebHostBuilder UseAppConfiguration(this IWebHostBuilder host)
        {
            host.ConfigureAppConfiguration((ctx, builder) =>
            {
                var env = ctx.HostingEnvironment;

                builder
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            });

            return host;
        }

    }
}
