using System;
using TouristConsole;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Tourist
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")                    
                var services = Startup.Configure();
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

