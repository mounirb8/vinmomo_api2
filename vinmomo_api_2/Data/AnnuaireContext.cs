using Microsoft.EntityFrameworkCore;
using vinmomo_api_2.Models;

namespace vinmomo_api_2.Data
{
    public class AnnuaireContext : DbContext
    {
        public AnnuaireContext(DbContextOptions<AnnuaireContext> options) : base(options) { }

        public DbSet<Salarie> Salaries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Site> Sites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salarie>()
                .HasOne(s => s.Service)
                .WithMany(s => s.Salaries)
                .HasForeignKey(s => s.ServiceId);

            modelBuilder.Entity<Salarie>()
                .HasOne(s => s.Site)
                .WithMany(s => s.Salaries)
                .HasForeignKey(s => s.SiteId);
        }
    }
}
