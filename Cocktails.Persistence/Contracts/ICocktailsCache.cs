using Cocktails.Application.Persistence.Contracts.Enums;
using Cocktails.Domain;

namespace Cocktails.Persistence.Contracts
{
    public interface ICocktailsCache
    {
        public Task<CocktailDetails?> GetAsync(int id);
        public Task AddAsync(CocktailDetails cocktail, TimeSpan expirationTime);

        public Task<List<Cocktail>?> GetAllByAlcoholAsync(AlcoholType alcoholType);
        public Task AddAllByAlcoholAsync(AlcoholType alcoholType, List<Cocktail> cocktails, TimeSpan expirationTime);
    }
}