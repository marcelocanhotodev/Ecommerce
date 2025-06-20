using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Product;
using Ecommerce.Application.UseCases.Models;
using FastEndpoints;

namespace Ecommerce.Api._Endpoints_.Product.GetAll
{
    public class Endpoint : EndpointWithoutRequest<ProductGetAllResponse>
    {
        private readonly IGetAllProductsUseCase _getAllProductsUseCase;
        public Endpoint(IProductRepository productRepository, IGetAllProductsUseCase getAllProductsUseCase)
        {
            _getAllProductsUseCase = getAllProductsUseCase ?? throw new ArgumentNullException(nameof(getAllProductsUseCase));
        }

        public override void Configure()
        {
            Get("product");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Get all products";
                s.Response<ProductGetAllResponse>(200);
            });
        }
        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var response = await _getAllProductsUseCase.ExecuteAsync(cancellationToken);
            await SendAsync(response);
        }
    }
}
