using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task PutProduct(int id, Product product);
        Task<Product> PostProduct(Product product);
        Task DeleteProduct(int id);
        bool ProductExists(int id);

    }
}
