using AspNetCoreAssessment.Filters;
using AspNetCoreAssessment.Foundation.Interfaces;
using AspNetCoreAssessment.Foundation.Services;
using Microsoft.OpenApi.Models;
using AspNetCoreAssessment.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetCoreAssessment
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<LoggingMiddleware>();

            services.AddSingleton<IStoreItemsService, StoreItemsService>();
            services.AddSingleton(new SpecificIdFilter(100));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreAssessment", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCoreAssessment v1"));
            }

            app.UseMiddleware<LoggingMiddleware>();

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                var endpoint = context.GetEndpoint();
                logger.LogInformation($"Current endpoint: {endpoint}");

                if (endpoint is RouteEndpoint routeEndpoint)
                {
                    logger.LogInformation("Endpoint has route pattern: " + routeEndpoint.RoutePattern.RawText);
                }

                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}