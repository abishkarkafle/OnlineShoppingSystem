using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Interface
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetBrands();
        Task<Brand> GetBrand(int id);
        Task PutBrand(int id, Brand brand);
        Task<Brand> PostBrand(Brand brand);
        Task DeleteBrand(int id);
        bool BrandExists(int id);
    }
}
