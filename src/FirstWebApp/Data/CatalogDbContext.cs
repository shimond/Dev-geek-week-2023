using FirstWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApp.Data
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }


        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {

        }

    }
}
