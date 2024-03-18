
using Microsoft.EntityFrameworkCore;

namespace ReactEcommerceApp.Server.Models
{
    public class WatchesDBContext : DbContext
    {
        public WatchesDBContext()
        {
        }
            public WatchesDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Product>().HasKey(i => new { i.Id});
            modelbuilder.Entity<Category>().HasKey(i => new { i.Id });
            modelbuilder.Entity<Cart>().HasKey(i => new { i.transactionid });
            modelbuilder.Entity<Order>().HasKey(i => new { i.id });
        }
    }
}
