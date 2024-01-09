using GraveyardManager.Model;
using Microsoft.EntityFrameworkCore;

namespace GraveyardManager.Data
{
    public class GraveyardDbContext : DbContext
    {
        public DbSet<Graveyard> Graveyards { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<Grave> Graves { get; set; }
        public DbSet<RemovedGrave> RemovedGraves { get; set;}
        public DbSet<Person> People { get; set; }
        //public DbSet<Columbarium> Columbaria { get; set; }
        //public DbSet<Niche> Niches { get; set; }

        public GraveyardDbContext(DbContextOptions<GraveyardDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grave>()
                .HasMany(e => e.People)
                .WithOne()
                .HasForeignKey(e => e.GraveId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
