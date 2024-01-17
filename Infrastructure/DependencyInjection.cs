using Infrastructure.Repository.Brands;
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

            return services;
        }
    }
}
