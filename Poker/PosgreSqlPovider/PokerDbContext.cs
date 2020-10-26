using Common;
using Microsoft.EntityFrameworkCore;

namespace PosgreSqlPovider
{
    public sealed class PokerDbContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerGameSnapshot> PlayerGameSnapshot { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<Round> Round{ get; set; }
        public DbSet<PlayerAction> PlayerAction { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Round>()
                .HasMany(p => p.StartedPlayers)
                .WithMany(b => b.StartedRounds)
                .UsingEntity(j => j.ToTable("StartedPlayerRound"));

            modelBuilder.Entity<Round>()
                .HasMany(p => p.FinishedPlayers)
                .WithMany(b => b.FinishedRounds)
                .UsingEntity(j => j.ToTable("FinishedPlayerRound"));

            modelBuilder.Entity<PlayerGameSnapshot>()
                .HasOne(p => p.Game)
                .WithMany(b => b.PlayerGameSnapshots);

            modelBuilder.Entity<PlayerGameSnapshot>()
                .HasOne(p => p.Player)
                .WithMany(b => b.PlayerGameSnapshots);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.Games)
                .WithMany(b => b.Players)
                .UsingEntity(j => j.ToTable("PlayerGame"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=poker;Username=postgres;Password=postgres");
        }
    }
}