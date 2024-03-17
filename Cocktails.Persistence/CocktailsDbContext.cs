using Cocktails.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cocktails.Persistence
{
    public class CocktailsDbContext : IdentityDbContext
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