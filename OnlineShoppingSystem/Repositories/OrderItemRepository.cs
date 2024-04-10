using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Data;
using OnlineShoppingSystem.Interface;
using OnlineShoppingSystem.Models;
namespace OnlineShoppingSystem.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly OnlineShoppingSystemContext _context;

        public OrderItemRepository(OnlineShoppingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems()
        {
            return await _context.OrderItem.ToListAsync();
        }

        public async Task<OrderItem> GetOrderItem(int id)
        {
            return await _context.OrderItem.FindAsync(id);
        }

        public async Task PutOrderItem(int id, OrderItem OrderItem)
        {
            if (id != OrderItem.Id)
            {
                throw new ArgumentException("Id mismatch");
            }

            _context.Entry(OrderItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<OrderItem> PostOrderItem(OrderItem OrderItem)
        {
            _context.OrderItem.Add(OrderItem);
            await _context.SaveChangesAsync();
            return OrderItem;
        }

        public async Task DeleteOrderItem(int id)
        {
            var OrderItem = await _context.OrderItem.FindAsync(id);
            _context.OrderItem.Remove(OrderItem);
            await _context.SaveChangesAsync();
        }

        public bool OrderItemExists(int id) // Implemented method
        {
            return _context.OrderItem.Any(e => e.Id == id);
        }
    }
}
