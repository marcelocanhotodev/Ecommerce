using Ecommerce.Application.Domain;
using Ecommerce.Application.UseCases.Models;

namespace Ecommerce.Application.UseCases.Interfaces
{
    public interface ICreateProductUseCase
    {
        Task<ProductCreateResponse> ExecuteAsync(ProductCreateRequest request, CancellationToken cancellationToken);

    }
}
