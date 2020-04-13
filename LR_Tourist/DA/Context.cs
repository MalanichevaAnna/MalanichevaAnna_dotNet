using DA.Data;
using Microsoft.EntityFrameworkCore;

namespace DA
{
    public class Context : DbContext
    {
        public DbSet<TravelVoucherDTO> TravelVouchers { get; set; }

        public DbSet<HotelDTO> Hotels { get; set; }

        public DbSet<Data.ServiceDTO> Services { get; set; }

        public DbSet<UserDTO> Users { get; set; }

        public DbSet<StaffDTO> Staffs { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=Tourist;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
