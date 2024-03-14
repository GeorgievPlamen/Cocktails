using Cocktails.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cocktails.Persistence
{
    public class CocktailsDbContext : DbContext
    {
        public CocktailsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CocktailsDbContext).Assembly);
        }

        public DbSet<FavoriteCocktail> FavoriteCocktails { get; set; }
    }
}