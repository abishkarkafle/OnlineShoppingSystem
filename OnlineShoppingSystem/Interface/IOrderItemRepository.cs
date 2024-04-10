using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Interface
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItems();
        Task<OrderItem> GetOrderItem(int id);
        Task PutOrderItem(int id, OrderItem orderItem);
        Task<OrderItem> PostOrderItem(OrderItem orderItem);
        Task DeleteOrderItem(int id);
        bool OrderItemExists(int id);
    }
}
