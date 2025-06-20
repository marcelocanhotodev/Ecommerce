using Dapper.Contrib.Extensions;
using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(string connectionString, ILogger<ProductRepository> logger)
        {
            _connectionString = connectionString.Trim().Trim('"').Trim('\'');
            _logger = logger;
        }

        public async Task<Product?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                return await conn.GetAsync<Product>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar produto por id.");
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                return await conn.GetAllAsync<Product>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os produtos.");
                throw;
            }
        }

        public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var id =  await conn.InsertAsync(product);
                return await conn.GetAsync<Product>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar produto.");
                throw;
            }
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                await conn.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar produto.");
                throw;
            }
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var product = await conn.GetAsync<Product>(id);
                if (product != null)
                    await conn.DeleteAsync(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar produto.");
                throw;
            }
        }
    }
}