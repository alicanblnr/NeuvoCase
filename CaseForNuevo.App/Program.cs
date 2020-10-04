using CaseForNuevo.Bussiness.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;


namespace CaseForNuevo.App
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceProvider serviceProvider = new ServiceCollection()
                       .AddTransient<Logger>()
                        .AddLogging(loggingBuilder =>
                        {
                            loggingBuilder.ClearProviders();
                            loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                            loggingBuilder.AddNLog();
                        })
                        .AddSingleton<ITCMBService, TCMBService>()
                        .AddSingleton<ILogger, Logger>()
                        .AddTransient<CaseApp>()
                       .BuildServiceProvider();
            var app = serviceProvider.GetService<CaseApp>();
            app.Run();
        }

    }
}
