using Cocktails.Application.Persistence.Contracts;
using Cocktails.Application.Persistence.Contracts.Enums;
using Cocktails.Domain;
using Cocktails.Persistence.Contracts;

namespace Cocktails.Persistence.Repositories
{
    public class CocktailRepository : ICocktailRepository
    {
        private readonly ICocktailApiGateway _apiGateway;
        private readonly ICocktailsCache _cache;
        public CocktailRepository(ICocktailApiGateway apiGateway, ICocktailsCache cache)
        {
            _cache = cache;
            _apiGateway = apiGateway;
        }
        public Task<CocktailDetails> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cocktail>> GetAllByAlcoholAsync(AlcoholType alcoholType)
        {
            return _apiGateway.GetAllByAlcoholAsync(alcoholType);
        }
    }
}