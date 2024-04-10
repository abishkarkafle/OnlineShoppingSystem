using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Data
{
    public class OnlineShoppingSystemContext : DbContext
    {
        public OnlineShoppingSystemContext (DbContextOptions<OnlineShoppingSystemContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineShoppingSystem.Models.User> User { get; set; } = default!;
        public DbSet<OnlineShoppingSystem.Models.Brand> Brand { get; set; } = default!;
        public DbSet<OnlineShoppingSystem.Models.Category> Category { get; set; } = default!;
        public DbSet<OnlineShoppingSystem.Models.Order> Order { get; set; } = default!;
        public DbSet<OnlineShoppingSystem.Models.OrderItem> OrderItem { get; set; } = default!;
        public DbSet<OnlineShoppingSystem.Models.Payment> Payment { get; set; } = default!;
        public DbSet<OnlineShoppingSystem.Models.Product> Product { get; set; } = default!;
        public DbSet<OnlineShoppingSystem.Models.Review> Review { get; set; } = default!;
        public DbSet<OnlineShoppingSystem.Models.Shipping> Shipping { get; set; } = default!;
    }
}
