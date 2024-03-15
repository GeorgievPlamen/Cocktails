using Cocktails.Domain;
using Cocktails.Persistence.Contracts;

namespace Cocktails.Infrastructure.Cache
{
    public class CocktailsCache : ICocktailsCache
    {
        public Task<bool> AddAsync(CocktailDetails cocktail)
        {
            throw new NotImplementedException();
        }

        public Task<CocktailDetails> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}