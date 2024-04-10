namespace OnlineShoppingSystem.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        // Navigation property for product
        public Product Product { get; set; }
        // Navigation property for user
        public User User { get; set; }
    }

}
