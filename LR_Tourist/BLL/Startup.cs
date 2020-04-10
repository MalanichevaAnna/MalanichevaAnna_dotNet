using AutoMapper;
using BLL;
using DA;
using DA.Services.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DI
{
    public static class Startup
    {
        public static ServiceProvider Configure()
        {
            var bl = Assembly.Load("BLL");
            var pl = Assembly.Load("TouristConsole");

            return new ServiceCollection()
                .AddDbContext<Context>()
                .AddTransient(typeof(IRepository<>), typeof(Repository<>))
                .Scan(scan=>scan
                    .FromAssemblies(bl,pl)
                    .AddClasses(classes=>classes.Where(type=>type.Name.EndsWith("Service")))
                    .AddClasses(classes => classes.Where(type => type.Name.StartsWith("Presentation")))
                    .AsSelf()
                    .WithTransientLifetime())
                .AddAutoMapper(typeof(MapperProfile))
                .BuildServiceProvider();
        }
    }
}
