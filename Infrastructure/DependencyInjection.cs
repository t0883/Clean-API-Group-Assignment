using Infrastructure.Repository.Brands;
using Infrastructure.Repository.Engines;
using Infrastructure.Repository.Engines.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IEngineRepository, EngineRepository>();

            return services;
        }
    }
}
