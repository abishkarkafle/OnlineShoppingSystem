using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Interface
{
    public interface IShippingRepository
    {
        Task<IEnumerable<Shipping>> GetShipping();
        Task<Shipping> GetShipping(int id);
        Task PutShipping(int id, Shipping shipping);
        Task<Shipping> PostShipping(Shipping shipping);
        Task DeleteShipping(int id);
        bool ShippingExists(int id);
    }
}
