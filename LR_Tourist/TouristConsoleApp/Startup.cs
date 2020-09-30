using AutoMapper;
using BLL;
using DA;
using DA.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.Reflection;
using TouristConsoleApp;

namespace TouristConsole
{
    public static class Startup
    {
        public static ServiceProvider Configure(IConfigurationRoot configuration)
        {
            var bl = Assembly.Load("BLL");
            var pl = Assembly.Load("TouristConsoleApp");

            return new ServiceCollection()
                .AddTransient<Runner>() // Runner is the custom class
                .AddLogging(loggingBuilder =>
                {
                  // configure Logging with NLog
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                    loggingBuilder.AddNLog(configuration);
                })
                .AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddTransient(typeof(IRepository<>), typeof(Repository<>))
                .Scan(scan => scan
                    .FromAssemblies(bl, pl)
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("ManagementService")))
                    .AddClasses(classes => classes.Where(type => type.Name.StartsWith("Presentation")))
                    .AsSelf()
                    .WithTransientLifetime())
                .AddAutoMapper(typeof(MapperProfile))
                .BuildServiceProvider();
        }
    }
}
