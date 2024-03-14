using Cocktails.Application.Persistence.Contracts;
using Cocktails.Application.Persistence.Contracts.Enums;
using Cocktails.Domain;

namespace Cocktails.Persistence.Repositories
{
    public class CocktailRepository : ICocktailRepository
    {
        public Task<CocktailDetails> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cocktail>> GetAllByAlcohol(AlcoholType alcoholType)
        {
            throw new NotImplementedException();
        }
    }
}