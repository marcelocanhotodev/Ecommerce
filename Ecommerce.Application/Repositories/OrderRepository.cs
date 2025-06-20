using Dapper.Contrib.Extensions;
using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(string connectionString, ILogger<OrderRepository> logger)
        {
            _connectionString = connectionString.Trim().Trim('"').Trim('\'');
            _logger = logger;
        }

        public async Task<Order?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                return await conn.GetAsync<Order>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar pedido pelo ID {OrderId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                return await conn.GetAllAsync<Order>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os pedidos.");
                throw;
            }
        }

        public async Task<Order> AddAsync(Order order, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var id = await conn.InsertAsync(order);
                return await conn.GetAsync<Order>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar pedido: {@Order}", order);
                throw;
            }
        }

        public async Task UpdateAsync(Order order, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                await conn.UpdateAsync(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar pedido: {@Order}", order);
                throw;
            }
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var order = await conn.GetAsync<Order>(id);
                if (order != null)
                    await conn.DeleteAsync(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar pedido com ID {OrderId}", id);
                throw;
            }
        }
    }
}