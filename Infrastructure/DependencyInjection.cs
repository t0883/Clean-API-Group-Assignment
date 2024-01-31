using Infrastructure.Repository.Brands;
using Infrastructure.Repository.Engines;
using Infrastructure.Repository.Engines.Interface;
using Infrastructure.Repository.Gearboxes;
using Infrastructure.Repository.Seats;
using Infrastructure.Repository.Tires;
using Infrastructure.Repository.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGearboxRepository, GearboxRepository>();
            services.AddScoped<ITireRepository, TireRepository>();
            services.AddScoped<IEngineRepository, EngineRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            return services;
        }
    }
}
