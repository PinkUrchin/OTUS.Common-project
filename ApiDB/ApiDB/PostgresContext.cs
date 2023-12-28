using Microsoft.EntityFrameworkCore;
using UfaData;

namespace UfaService.Model
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
            optionsBuilder.UseNpgsql("Host=postgres;Port=5432;Database=postgres;Username=postgres;Password=postgres");
        }
    }
}
