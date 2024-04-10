using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Data;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;
namespace OnlineShoppingSystem.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnlineShoppingSystemContext _context;

        public CategoryRepository(OnlineShoppingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async Task PutCategory(int id, Category Category)
        {
            if (id != Category.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(Category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Category> PostCategory(Category Category)
        {
            _context.Category.Add(Category);
            await _context.SaveChangesAsync();
            return Category;
        }

        public async Task DeleteCategory(int id)
        {
            var Category = await _context.Category.FindAsync(id);
            _context.Category.Remove(Category);
            await _context.SaveChangesAsync();
        }

        public bool CategoryExists(int id) // Implemented method
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}
