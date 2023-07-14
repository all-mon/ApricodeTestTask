using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Genres)
                .WithMany(g => g.Games)
                .UsingEntity<GameGenre>();
        }
    }
}
