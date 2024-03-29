﻿using Domain.Models.Brands;
using Domain.Models.Cars;
using Domain.Models.Engines;
using Domain.Models.Gearboxes;
using Domain.Models.Seats;
using Domain.Models.Tires;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database.SqlDatabase
{
    public class SqlServer : DbContext
    {
        private readonly IConfiguration _configuration;

        public SqlServer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }
        public virtual DbSet<Gearbox> GearBoxes { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Tire> Tires { get; set; }

        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Car> Cars { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>().HasIndex(x => x.BrandName).IsUnique();

            modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();

            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
        }
    }
}
