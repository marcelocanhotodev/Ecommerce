using Ecommerce.Application.UseCases.Models;

namespace Ecommerce.Application.UseCases.Interfaces.Product
{
    public interface IGetAllProductsUseCase
    {
        Task<ProductGetAllResponse> ExecuteAsync(ProductGetAllRequest request, CancellationToken cancellationToken);
    }
}
