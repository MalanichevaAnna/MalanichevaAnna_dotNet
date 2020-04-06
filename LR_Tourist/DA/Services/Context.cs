﻿using DA.Data;
using Microsoft.EntityFrameworkCore;

namespace DA.Services
{
    public class Context : DbContext
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
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=Tourist;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
