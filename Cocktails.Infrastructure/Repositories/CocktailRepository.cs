
using Cocktails.Application.Interfaces;
using Cocktails.Domain;
using Cocktails.Domain.Enums;
using Cocktails.Infrastructure.Interfaces;

namespace Cocktails.Infrastructure.Repositories
{
    public class CocktailRepository : ICocktailRepository
    {
        private readonly ICocktailApiGateway _apiGateway;
        private readonly ICocktailsCache _cache;
        private TimeSpan expirationTime = TimeSpan.FromDays(1);
        public CocktailRepository(ICocktailApiGateway apiGateway, ICocktailsCache cache)
        {
            _cache = cache;
            _apiGateway = apiGateway;
        }
        public async Task<CocktailDetails> GetAsync(int id)
        {
            CocktailDetails? result = await _cache.GetAsync(id);
            if (result == null)
            {
                result = await _apiGateway.GetAsync(id);
                await _cache.AddAsync(result, expirationTime);
            }

            return result;
        }

        public async Task<List<Cocktail>> GetAllByAlcoholAsync(AlcoholType alcoholType)
        {
            var result = await _cache.GetAllByAlcoholAsync(alcoholType);
            if (result == null)
            {
                result = await _apiGateway.GetAllByAlcoholAsync(alcoholType);
                await _cache.AddAllByAlcoholAsync(alcoholType, result, expirationTime);
            }
            return result;
        }
    }
}