using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Data;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;
namespace OnlineShoppingSystem.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineShoppingSystemContext _context;

        public OrderRepository(OnlineShoppingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Order.FindAsync(id);
        }

        public async Task PutOrder(int id, Order Order)
        {
            if (id != Order.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(Order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Order> PostOrder(Order Order)
        {
            _context.Order.Add(Order);
            await _context.SaveChangesAsync();
            return Order;
        }

        public async Task DeleteOrder(int id)
        {
            var Order = await _context.Order.FindAsync(id);
            _context.Order.Remove(Order);
            await _context.SaveChangesAsync();
        }

        public bool OrderExists(int id) // Implemented method
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
