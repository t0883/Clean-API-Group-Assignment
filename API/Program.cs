using Application;
using Infrastructure;
using Infrastructure.Database.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

            // Add services to the container.
            builder.Services.AddDbContext<SqlServer>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure"));
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplication().AddInfrastructure();

            builder.Services.AddScoped<Infrastructure.Repository.Engines.Interface.IEngineRepository, Infrastructure.Repository.Engines.EngineRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Add this line to configure routing.
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}