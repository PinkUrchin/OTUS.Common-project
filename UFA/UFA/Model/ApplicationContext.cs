using Microsoft.EntityFrameworkCore;
using UfaData;

namespace UfaService.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<Primitive> Primitives { get; set; }
        public DbSet<Document> Documents { get; set; }
        
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123");
        }
    }
}
