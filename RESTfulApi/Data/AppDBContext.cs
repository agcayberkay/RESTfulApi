using Microsoft.EntityFrameworkCore;
using RESTfulApi.Models;

namespace RESTfulApi.Data
{
    public class AppDBContext:DbContext
    {

        // Veri Tabanı Bağlantısı
        public AppDBContext(DbContextOptions<AppDBContext> options) : base (options) { }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "Laptop", Price = 15000, Stock = 10 },
                new Products { Id = 2, Name = "Telefon", Price = 12000, Stock = 20 },
                new Products { Id = 3, Name = "Kulaklık", Price = 500, Stock = 50 }
            );
        }
    }
}
