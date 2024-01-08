using Microsoft.EntityFrameworkCore;
using DataProvider;

namespace DataProvider
{    
    public class PostgresContext : DbContext
    {
        public DbSet<dw_shape_type> dw_shape_type { get; set; }
        public DbSet<dw_shape> dw_shapes { get; set; }
        public DbSet<dw_document> dw_documents { get; set; }

        public PostgresContext()
        {            
            Database.EnsureCreated();            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");
        }
    }
}
