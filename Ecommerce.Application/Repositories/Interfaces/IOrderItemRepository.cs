using Ecommerce.Application.Domain;

namespace Ecommerce.Application.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<OrderItem> AddAsync(OrderItem orderItem, CancellationToken cancellationToken = default);
        Task UpdateAsync(OrderItem orderItem, CancellationToken cancellationToken = default);
        Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}
