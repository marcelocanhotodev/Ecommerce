using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Product;
using Ecommerce.Application.UseCases.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.UseCases.Product
{
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<Domain.Product> _productValidator;
        private readonly ILogger<CreateProductUseCase> _logger;

        public CreateProductUseCase(IProductRepository productRepository, IValidator<Domain.Product> productValidator, ILogger<CreateProductUseCase> logger)
        {
            _productRepository = productRepository;
            _productValidator = productValidator;
            _logger = logger;
        }

        public async Task<ProductCreateResponse> ExecuteAsync(ProductCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Domain.Product
                {
                    ean = request.Ean,
                    brandid = request.BrandId,
                    name = request.Name,
                    description = request.Description
                };

                await _productValidator.ValidateAndThrowAsync(product, cancellationToken);

                var productResponse = await _productRepository.AddAsync(product, cancellationToken);

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
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation failed for product creation: {@Errors}", ex.Errors);
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
