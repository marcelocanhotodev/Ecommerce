using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces;
using Ecommerce.Application.UseCases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases
{
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public CreateProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductCreateResponse> ExecuteAsync(ProductCreateRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ean = request.Ean,
                brandid = request.BrandId,
                name = request.Name,
                description = request.Description
            };

            var productResponse = await _productRepository.SaveProduct(product);

            return new ProductCreateResponse
            {
                Id = productResponse.id,
                Ean = productResponse.ean,
                BrandId = productResponse.brandid,
                Name = productResponse.name,
                Description = productResponse.description,
                CreatedAt = productResponse.createdat,
                UpdatedAt = productResponse.updatedat
            };
        }
    }
}
