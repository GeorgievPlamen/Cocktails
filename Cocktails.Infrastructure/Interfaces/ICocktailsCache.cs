
using Cocktails.Domain;
using Cocktails.Domain.Enums;

namespace Cocktails.Infrastructure.Interfaces
{
    public interface ICocktailsCache
    {
        public Task<CocktailDetails?> GetAsync(int id);
        public Task AddAsync(CocktailDetails cocktail, TimeSpan expirationTime);

        public Task<List<Cocktail>?> GetAllByAlcoholAsync(AlcoholType alcoholType);
        public Task AddAllByAlcoholAsync(AlcoholType alcoholType, List<Cocktail> cocktails, TimeSpan expirationTime);
    }
}