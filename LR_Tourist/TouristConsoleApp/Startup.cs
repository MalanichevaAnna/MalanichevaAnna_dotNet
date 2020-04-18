using AutoMapper;
using BLL;
using DA;
using DA.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TouristConsole
{
    public static class Startup
    {
        public static ServiceProvider Configure(IConfigurationRoot configuration)
        {
            var bl = Assembly.Load("BLL");
            var pl = Assembly.Load("TouristConsoleApp");

            return new ServiceCollection()
                .AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddTransient(typeof(IRepository<>), typeof(Repository<>))
                .Scan(scan => scan
                    .FromAssemblies(bl, pl)
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("IEntityManagementService")))
                    .AddClasses(classes => classes.Where(type => type.Name.StartsWith("Presentation")))
                    .AsSelf()
                    .WithTransientLifetime())
                .AddAutoMapper(typeof(MapperProfile))
                .BuildServiceProvider();
        }
    }
}
