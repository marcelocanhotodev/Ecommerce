using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Product;
using Ecommerce.Application.UseCases.Models;

namespace Ecommerce.Application.UseCases.Product
{
    public class GetAllProductsUseCase : IGetAllProductsUseCase
    {

        private readonly IProductRepository _productRepository;

        public GetAllProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<ProductGetAllResponse> ExecuteAsync(CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            var response = new ProductGetAllResponse
            {
                Products = products.Select(p => new ProductCreateResponse
                {
                    Id = p.id,
                    Ean = p.ean,
                    BrandId = p.brandid,
                    Name = p.name,
                    Description = p.description,
                    CreatedAt = p.createdat,
                    UpdatedAt = p.updatedat
                }).ToList()
            };

            return response;
        }
    }
}
