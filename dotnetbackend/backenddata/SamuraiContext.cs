using Microsoft.EntityFrameworkCore;
using backenddomain;

namespace backenddata
{
    public class SamuraiContext: DbContext 
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
    }
}