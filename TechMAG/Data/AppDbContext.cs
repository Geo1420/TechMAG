using Microsoft.EntityFrameworkCore;
using TechMAG.Models;

namespace TechMAG.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Producer>? Producers { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductImage>? ProductImages { get; set; }

        //Order related tables
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<ShoppingCartItem>? ShoppingCartItems { get; set; }
    }
}
