using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNetCore.Services;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace ApiNetCore.Configuration
{
    public static class ServiceDependencyConfiguration
    {
        public static IServiceCollection RegisterDependentServices(this IServiceCollection services)
        {

            // -- add required dependent services
            services.AddTransient<IExampleService, ExampleService>();

            return services;
        }
    }
}
