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

        public DbSet<FavoriteCocktail> FavoriteCocktails { get; set; }
    }
}