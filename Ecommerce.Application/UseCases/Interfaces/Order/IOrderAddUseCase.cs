using Ecommerce.Application.UseCases.Models;

namespace Ecommerce.Application.UseCases.Interfaces.Order
{
    public interface IOrderAddUseCase
    {
        Task<OrderCreateResponse> ExecuteAsync(OrderCreateRequest req, CancellationToken cancellationToken = default);
    }
}
