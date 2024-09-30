using Microsoft.EntityFrameworkCore;
using TeamHeritageShared.Models;

namespace TeamHeritageAPI.Banco
{
    public class TeamHeritageDbContext : DbContext
    {
        public TeamHeritageDbContext(DbContextOptions<TeamHeritageDbContext> options) : base(options) { }

        public DbSet<Time> Times { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura a relação de um-para-muitos entre Time e Titulo
            modelBuilder.Entity<Time>()
                .HasMany(t => t.Titulos)
                .WithOne(t => t.Time)
                .HasForeignKey(t => t.TimeId);

            base.OnModelCreating(modelBuilder);
        }
    }

}