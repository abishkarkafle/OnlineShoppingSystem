using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Data;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;
namespace OnlineShoppingSystem.Repository
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly OnlineShoppingSystemContext _context;

        public ShippingRepository(OnlineShoppingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipping>> GetShipping()
        {
            return await _context.Shipping.ToListAsync();
        }

        public async Task<Shipping> GetShipping(int id)
        {
            return await _context.Shipping.FindAsync(id);
        }

        public async Task PutShipping(int id, Shipping shipping)
        {
            if (id != shipping.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(shipping).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Shipping> PostShipping(Shipping shipping)
        {
            _context.Shipping.Add(shipping);
            await _context.SaveChangesAsync();
            return shipping;
        }

        public async Task DeleteShipping(int id)
        {
            var shipping = await _context.Shipping.FindAsync(id);
            _context.Shipping.Remove(shipping);
            await _context.SaveChangesAsync();
        }

        public bool ShippingExists(int id) // Implemented method
        {
            return _context.Shipping.Any(e => e.Id == id);
        }
    }
}
