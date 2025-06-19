using Ecommerce.Application.Domain;

namespace Ecommerce.Application.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();

        Task<Product> SaveProduct(Product product);
    }
}
