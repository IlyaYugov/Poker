using Common;
using Microsoft.EntityFrameworkCore;

namespace PosgreSqlPovider
{
    public sealed class PokerDbContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<Round> Round{ get; set; }
        public DbSet<PlayerAction> PlayerAction { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistic { get; set; }

        public PokerDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");
        }
    }
}