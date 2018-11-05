using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiNetCore.Configuration

{
    public static class SwaggerConfiguration
    {

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Skeleton Project API v1", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.DescribeAllEnumsAsStrings();
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerApp(this IApplicationBuilder app)
        {
            app.UseSwagger()

               .UseSwaggerUI(c =>
               {
                    c.InjectStylesheet("/swagger/swagger-ui.css");
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FIIG FinTechTools API v1");
                    c.RoutePrefix = "swagger";
               });

            return app;
        }
    }
}




