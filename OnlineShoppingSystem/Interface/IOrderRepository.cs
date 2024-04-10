using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int id);
        Task PutOrder(int id, Order order);
        Task<Order> PostOrder(Order order);
        Task DeleteOrder(int id);
        bool OrderExists(int id);
    }
}
