using DA.Data;
using Microsoft.EntityFrameworkCore;

namespace DA
{
    public class Context : DbContext
    {
        public DbSet<TravelVoucherDTO> TravelVouchers { get; set; }

        public DbSet<HotelDTO> Hotels { get; set; }

        public DbSet<ServiceDTO> Services { get; set; }

        public DbSet<UserDTO> Users { get; set; }

        public DbSet<StaffDTO> Staffs { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
