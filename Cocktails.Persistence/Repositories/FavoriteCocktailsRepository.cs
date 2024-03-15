using Cocktails.Application.Persistence.Contracts;
using Cocktails.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cocktails.Persistence.Repositories
{
    public class FavoriteCocktailsRepository : IFavoriteCocktailsRepository
    {
        private readonly CocktailsDbContext _dbContext;
        public FavoriteCocktailsRepository(CocktailsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(FavoriteCocktail entity)
        {
            await _dbContext.FavoriteCocktails.AddAsync(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(FavoriteCocktail entity)
        {
            _dbContext.FavoriteCocktails.Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<FavoriteCocktail> GetAsync(int id)
        {
            var cocktail = await _dbContext.FavoriteCocktails
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return cocktail ?? throw new ArgumentNullException(nameof(cocktail));
        }

        public async Task<List<FavoriteCocktail>> GetAllByUserAsync(string userId)
        {
            var cocktails = await _dbContext.FavoriteCocktails
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return cocktails;
        }
    }
}