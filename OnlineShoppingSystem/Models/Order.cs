namespace OnlineShoppingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string Notes { get; set; }

        // Navigation property for user
        public User User { get; set; }
        // Navigation property for order items
        public List<OrderItem> OrderItems { get; set; }
        // Navigation property for payments
        public Payment Payment { get; set; }
    }

}
