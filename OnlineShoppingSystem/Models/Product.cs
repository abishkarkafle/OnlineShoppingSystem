namespace OnlineShoppingSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int StockQuantity { get; set; }
        public float Weight { get; set; }
        public string Dimensions { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Navigation property for category
        public Category Category { get; set; }
        // Navigation property for brand
        public Brand Brand { get; set; }
        // Navigation property for order items
        public List<OrderItem> OrderItems { get; set; }
        // Navigation property for reviews
        public List<Review> Reviews { get; set; }
    }

}
