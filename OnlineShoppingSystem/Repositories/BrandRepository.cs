using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Data;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;
namespace OnlineShoppingSystem.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly OnlineShoppingSystemContext _context;

        public BrandRepository(OnlineShoppingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _context.Brand.ToListAsync();
        }

        public async Task<Brand> GetBrand(int id)
        {
            return await _context.Brand.FindAsync(id);
        }

        public async Task PutBrand(int id, Brand Brand)
        {
            if (id != Brand.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(Brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Brand> PostBrand(Brand Brand)
        {
            _context.Brand.Add(Brand);
            await _context.SaveChangesAsync();
            return Brand;
        }

        public async Task DeleteBrand(int id)
        {
            var Brand = await _context.Brand.FindAsync(id);
            _context.Brand.Remove(Brand);
            await _context.SaveChangesAsync();
        }

        public bool BrandExists(int id) // Implemented method
        {
            return _context.Brand.Any(e => e.Id == id);
        }
    }
}
