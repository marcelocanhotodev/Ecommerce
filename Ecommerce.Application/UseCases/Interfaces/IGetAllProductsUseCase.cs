using Ecommerce.Application.UseCases.Models;

namespace Ecommerce.Application.UseCases.Interfaces
{
    public interface IGetAllProductsUseCase
    {
        Task<ProductGetAllResponse> ExecuteAsync(ProductGetAllRequest request, CancellationToken cancellationToken);
    }
}
