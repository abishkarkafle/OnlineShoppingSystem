namespace OnlineShoppingSystem.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }

        // Navigation property for order
        public Order Order { get; set; }
        // Navigation property for product
        public Product Product { get; set; }
    }

}
