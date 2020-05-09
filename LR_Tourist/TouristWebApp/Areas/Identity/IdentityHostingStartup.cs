using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TouristWebApp.Data;

[assembly: HostingStartup(typeof(TouristWebApp.Areas.Identity.IdentityHostingStartup))]
namespace TouristWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TouristWebAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TouristWebAppContextConnection")));
               // .AddIdentity<IdentityUser, IdentityRole>()
               //.AddEntityFrameworkStores<TouristWebAppContext>();
                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<TouristWebAppContext>();
            });
        }
    }
}