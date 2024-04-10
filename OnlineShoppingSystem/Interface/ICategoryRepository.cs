using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task PutCategory(int id, Category shipping);
        Task<Category> PostCategory(Category shipping);
        Task DeleteCategory(int id);
        bool CategoryExists(int id);
    }
}
