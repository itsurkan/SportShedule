using Microsoft.EntityFrameworkCore;

namespace SportSchedule.Models
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options)
            : base(options)
        {
        }

        public DbSet<TournamentModel> Tournament { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TourMatch> Match { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TournamentModel>()
                .HasMany(a => a.Matches)
                .WithOne(b => b.Tournament)
                .HasForeignKey(b => b.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}