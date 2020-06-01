using System.Reflection;
using AutoMapper;
using BLL;
using DA;
using DA.Services.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TouristWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
     
            var bl = Assembly.Load("BLL");

            services
            .AddTransient(typeof(IRepository<>), typeof(Repository<>))
            .Scan(scan => scan
                .FromAssemblies(bl)
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("ManagementService")))
                .AsSelf()
                .WithTransientLifetime())
            .AddAutoMapper(typeof(MapperProfile));
            services.AddIdentity<IdentityUser, IdentityRole>(options => { options.Password.RequireNonAlphanumeric = false; })
                    .AddEntityFrameworkStores<Context>();
            services.AddSwaggerGen();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(swagger =>
            {
                swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API");
                swagger.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
