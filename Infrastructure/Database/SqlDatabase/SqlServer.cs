using Domain.Models.Brands;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"));
        }
    }
}
