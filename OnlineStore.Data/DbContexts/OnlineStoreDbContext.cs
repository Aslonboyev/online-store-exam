using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Contacts;
using OnlineStore.Domain.Entities.Discounts;
using OnlineStore.Domain.Entities.Locations;
using OnlineStore.Domain.Entities.Orders;
using OnlineStore.Domain.Entities.Products;
using OnlineStore.Domain.Entities.Users;

namespace OnlineStore.Data.DbContexts
{
    public class OnlineStoreDbContext : DbContext
    {
        private readonly string ConnectionString = "Host=localhost;Port=5432;Database=OnlineStore-Exam-Project;Username=postgres;Password=7458;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}
