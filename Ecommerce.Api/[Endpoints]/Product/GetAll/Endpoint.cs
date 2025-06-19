using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases;
using Ecommerce.Application.UseCases.Interfaces;
using Ecommerce.Application.UseCases.Models;
using FastEndpoints;

namespace Ecommerce.Api._Endpoints_.Product.GetAll
{
    public class Endpoint : Endpoint<ProductGetAllRequest, ProductGetAllResponse>
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
        public override async Task HandleAsync(ProductGetAllRequest request, CancellationToken cancellationToken)
        {
            var response = await _getAllProductsUseCase.ExecuteAsync(request, cancellationToken);
            await SendAsync(response);
        }
    }
}
