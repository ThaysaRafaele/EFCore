using EFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItem> OrdersItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=Tambor2022@@;Integrated Security=False;TrustServerCertificate=True;User ID=sa; Initial Catalog=EFCore-DB_WebAPI;Data Source=SEVEN-P0224\\SQL");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId });
            });
        }
    }
}