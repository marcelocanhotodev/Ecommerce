using Ecommerce.Application.Repositories;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Order;
using Ecommerce.Application.UseCases.Interfaces.Participant;
using Ecommerce.Application.UseCases.Interfaces.Product;
using Ecommerce.Application.UseCases.Order;
using Ecommerce.Application.UseCases.Participant;
using Ecommerce.Application.UseCases.Product;
using Ecommerce.Infrastructure.Repositories;

namespace Ecommerce.Api.Infrastructure
{
    public static class UseCaseInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            services.AddScoped<IGetAllProductsUseCase, GetAllProductsUseCase>();
            services.AddScoped<IParticipantAddUseCase, ParticipantAddUseCase>();
            services.AddScoped<IParticipantGetAllUseCase, ParticipantGetAllUseCase>();
            services.AddScoped<IOrderAddUseCase, OrderAddUseCase>();

            return services;
        }
    }
}
