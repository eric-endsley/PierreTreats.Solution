using Microsoft.EntityFrameworkCore;

namespace PierreTreats.Models
{
    public class PierreTreatsContext : DbContext
    {
        public virtual DbSet<Treat> Treats { get; set; }
        public virtual DbSet<Flavor> Flavors { get; set; }
        public virtual DbSet<TreatFlavor> TreatFlavors { get; set; }

        public PierreTreatsContext(DbContextOptions options) : base(options) { } 
    }
}