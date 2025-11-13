using Microsoft.EntityFrameworkCore;
using vinmomo_api_2.Models;

namespace vinmomo_api_2.Data
{
    public class AnnuaireContext : DbContext
    {
        public AnnuaireContext(DbContextOptions<AnnuaireContext> options)
            : base(options)
        {
        }

        public DbSet<Salarie> Salaries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Site> Sites { get; set; }

    }
}
