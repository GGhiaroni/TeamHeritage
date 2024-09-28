using Microsoft.EntityFrameworkCore;
using TeamHeritageShared.Models;

namespace TeamHeritageAPI.Banco
{
    public class TeamHeritageDbContext : DbContext
    {
        public TeamHeritageDbContext(DbContextOptions<TeamHeritageDbContext> options) : base(options) { }

        public DbSet<Time> Times { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
    }

}