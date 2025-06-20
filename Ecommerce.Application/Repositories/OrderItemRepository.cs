using Dapper.Contrib.Extensions;
using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<OrderItemRepository> _logger;

        public OrderItemRepository(string connectionString, ILogger<OrderItemRepository> logger)
        {
            _connectionString = connectionString.Trim().Trim('"').Trim('\'');
            _logger = logger;
        }

        public async Task<OrderItem?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                return await conn.GetAsync<OrderItem>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar item do pedido pelo ID {OrderItemId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                return await conn.GetAllAsync<OrderItem>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os itens de pedido.");
                throw;
            }
        }

        public async Task<OrderItem> AddAsync(OrderItem orderItem, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var id = await conn.InsertAsync(orderItem);
                return await conn.GetAsync<OrderItem>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar item de pedido: {@OrderItem}", orderItem);
                throw;
            }
        }

        public async Task UpdateAsync(OrderItem orderItem, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                await conn.UpdateAsync(orderItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar item de pedido: {@OrderItem}", orderItem);
                throw;
            }
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var orderItem = await conn.GetAsync<OrderItem>(id);
                if (orderItem != null)
                    await conn.DeleteAsync(orderItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar item de pedido com ID {OrderItemId}", id);
                throw;
            }
        }
    }
}