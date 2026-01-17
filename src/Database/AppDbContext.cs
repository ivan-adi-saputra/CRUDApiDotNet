using CRUDApiDotNet.src.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApiDotNet.src.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}