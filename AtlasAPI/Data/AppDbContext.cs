using AtlasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AtlasPhoto> Photos { get; set; }
    }
}
