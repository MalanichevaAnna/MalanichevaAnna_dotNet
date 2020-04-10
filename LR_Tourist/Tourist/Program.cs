using DI;
using System;
using TouristConsole;
using Microsoft.Extensions.DependencyInjection;

namespace Tourist
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = Startup.Configure();
            var mainPresentation = services.GetService<PresentationMenu>();
            mainPresentation.PrintMenu();

            }
        }
        
    }

