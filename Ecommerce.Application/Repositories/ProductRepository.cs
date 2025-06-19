using Dapper;
using Dapper.Contrib.Extensions;
using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Npgsql;

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

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var products = await conn.GetAllAsync<Product>();
                return products.AsList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os produtos.");
                throw;
            }
        }

        public async Task<Product> SaveProduct(Product product)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var id = await conn.InsertAsync<Product>(product);
                var result = await conn.GetAsync<Product>(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar o produto.");
                throw;
            }
        }
    }
}
