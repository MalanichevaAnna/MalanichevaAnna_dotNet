using DI;
using System;
using TouristConsole;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Tourist
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                var services = Startup.Configure();
                var mainPresentation = services.GetService<PresentationMenu>();
                mainPresentation.StartAppSession();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }
    }        
}

