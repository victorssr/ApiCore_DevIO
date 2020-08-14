using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace VSDev.Api.Configurations
{
    public static class LoggerConfig
    {

        public static IServiceCollection AddLoggerConfig(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "3eaa16ba82fa42348865282a30e5db2f";
                o.LogId = new Guid("897d3ccc-8333-4e57-bce7-3022b226144d");
            });

            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "3eaa16ba82fa42348865282a30e5db2f";
                    o.LogId = new Guid("897d3ccc-8333-4e57-bce7-3022b226144d");
                });

                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });

            return services;
        }

        public static IApplicationBuilder UseLoggerConfig(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
