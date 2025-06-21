using Ecommerce.Application.Repositories;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Infrastructure.Repositories;

namespace Ecommerce.Api.Infrastructure
{
    public static class RepositoryInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Postgres")
            ?? throw new Exception("Connection string 'Postgres' not found.");

            services.AddScoped<IProductRepository>(sp => new ProductRepository(connectionString, null!));
            services.AddScoped<IParticipantRepository>(sp => new ParticipantRepository(connectionString, null!));
            services.AddScoped<IOrderRepository>(sp => new OrderRepository(connectionString, null!));

            return services;
        }
    }
}
