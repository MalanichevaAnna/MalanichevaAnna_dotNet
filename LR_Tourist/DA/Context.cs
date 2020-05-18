using DA.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DA
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public DbSet<TravelVoucherDTO> TravelVouchers { get; set; }

        public DbSet<HotelDTO> Hotels { get; set; }

        public DbSet<ServiceDTO> Services { get; set; }

        public DbSet<UserDTO> AppUsers { get; set; }

        public DbSet<StaffDTO> Staffs { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            if (!Database.CanConnect() && !Database.EnsureCreated())
            {
                throw new InvalidOperationException("Database was not created properly.");
            }
        }
    }
}
