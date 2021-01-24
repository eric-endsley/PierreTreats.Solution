using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierreTreats.Models
{
    public class PierreTreatsContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Treat> Treats { get; set; }
        public virtual DbSet<Flavor> Flavors { get; set; }
        public virtual DbSet<TreatFlavor> TreatFlavor { get; set; }

        public PierreTreatsContext(DbContextOptions options) : base(options) { } 
    }
}