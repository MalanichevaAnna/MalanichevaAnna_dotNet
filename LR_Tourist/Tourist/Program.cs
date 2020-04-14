using System;
using TouristConsole;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Tourist
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                var services = Startup.Configure(config);
                var mainPresentation = services.GetService<PresentationMenu>();
                await mainPresentation.StartAppSession();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }
    }
}

