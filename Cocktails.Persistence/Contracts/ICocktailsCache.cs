using Cocktails.Domain;

namespace Cocktails.Persistence.Contracts
{
    public interface ICocktailsCache
    {
        public Task<CocktailDetails> GetAsync(int id);
        public Task<bool> AddAsync(CocktailDetails cocktail);
    }
}