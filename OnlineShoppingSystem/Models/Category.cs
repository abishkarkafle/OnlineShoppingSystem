namespace OnlineShoppingSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }

        // Navigation property for products
        public List<Product> Products { get; set; }
    }

}
