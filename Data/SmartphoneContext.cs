using Microsoft.EntityFrameworkCore;
using netCoreRestApiEf.Model;

namespace netCoreRestApiEf.Data
{
    public class SmartphoneContext : DbContext
    {
        public SmartphoneContext(DbContextOptions<SmartphoneContext> options) : base(options)
        {
            
        }
        public DbSet<Smartphone> Smartphones { get; set; }
    }
}