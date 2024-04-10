namespace OnlineShoppingSystem.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EstimatedDeliveryTime { get; set; }
        public decimal Cost { get; set; }
        public string TrackingNumber { get; set; }
    }

}
