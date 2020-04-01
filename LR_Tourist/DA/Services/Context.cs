using DA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DA.Services
{
    public class Context<T> : DbContext
        where T : class
    {
        public DbSet<TravelVoucher> TravelVouchers { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Data.Services> Services { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        //}
    }
}
