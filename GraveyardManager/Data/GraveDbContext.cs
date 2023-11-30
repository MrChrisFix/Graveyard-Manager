using GraveyardManager.Model;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Data
{ //TODO: change name to GraveyardDbContext?
    public class GraveDbContext : DbContext
    {
        public DbSet<Graveyard> Graveyards { get; set; }
        public DbSet<Grave> Graves { get; set; }
        public DbSet<RemovedGrave> RemovedGraves { get; set;}
        public DbSet<Plot> Plots { get; set; }

        public GraveDbContext(DbContextOptions<GraveDbContext> options) : base(options)
        {
        }
    }
}
