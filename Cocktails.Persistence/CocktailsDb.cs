using Cocktails.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cocktails.Persistence
{
    public class CocktailsDb : DbContext
    {
        public CocktailsDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FavoriteCocktail> FavoriteCocktails { get; set; }
    }
}