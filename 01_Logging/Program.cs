using Exceptionless;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;
using System;



namespace _01_Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            ///模拟startup实例一个ServiceCollection 
            ServiceCollection services = new ServiceCollection();
            ExceptionlessClient.Default.Startup("你的apikey");
            services.AddLogging(
                logBuilder=>
                {
                    Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .Enrich.FromLogContext()
                    .WriteTo.Console(new JsonFormatter())
                    .WriteTo.Exceptionless()
                    .CreateLogger();
                    logBuilder.AddSerilog();
                }
                );
            //注册服务
            services.AddScoped<SystemService>();
            //通过服务构建容器，ServiceProvider类型
            using (var sp = services.BuildServiceProvider())
            { ///获取容器中的服务ITestService
                var test2 = sp.GetRequiredService<SystemService>();
                    test2.Logging();
              
            }
        }
    }
}
