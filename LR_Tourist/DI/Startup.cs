using BLL.Interfaces;
using BLL.Model;
using BLL.Services;
using DA.Data;
using DA.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public class Startup
    {
        public void ConfigureServicesHotel(IServiceCollection services)
        {
            services.AddTransient<BLL.Interfaces.IService<ProfileHotel>, HotelService>();
            services.AddTransient<HotelService>();
        }

        public void ConfigureServicesService(IServiceCollection services)
        {
            services.AddTransient<BLL.Interfaces.IService<ProfileServices>, ServiceService>();
            services.AddTransient<ServiceService>();
        }

        public void ConfigureServicesTravelVouchers(IServiceCollection services)
        {
            services.AddTransient<BLL.Interfaces.ITravelVoucher, TravelVoucherServices>();
            services.AddTransient<TravelVoucherServices>();
        }

        public void ConfigureServicesUser(IServiceCollection services)
        {
            services.AddTransient<BLL.Interfaces.IService<ProfileUser>, UserService>();
            services.AddTransient<UserService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<UserService>();
        }
    }
}
