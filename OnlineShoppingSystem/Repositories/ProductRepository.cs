using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Data;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;
namespace OnlineShoppingSystem.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShoppingSystemContext _context;

        public ProductRepository(OnlineShoppingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task PutProduct(int id, Product Product)
        {
            if (id != Product.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Product> PostProduct(Product Product)
        {
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();
            return Product;
        }

        public async Task DeleteProduct(int id)
        {
            var Product = await _context.Product.FindAsync(id);
            _context.Product.Remove(Product);
            await _context.SaveChangesAsync();
        }

        public bool ProductExists(int id) // Implemented method
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
