using Infrastructure.Repository.Brands;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
