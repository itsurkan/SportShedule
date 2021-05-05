using Microsoft.EntityFrameworkCore;
using SportSchedule.Core.EntityConfigurations;
using SportSchedule.Core.Models;

namespace SportSchedule.Core.DbContexts
{
    public class SportContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Team> Teams { get; set; }

        public SportContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SportSchedule.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoundEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TeamEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentEntityConfiguration());
        }
    }
}
