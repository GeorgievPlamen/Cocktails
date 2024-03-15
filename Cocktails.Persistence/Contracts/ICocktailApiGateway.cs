using Cocktails.Application.Persistence.Contracts.Enums;
using Cocktails.Domain;

namespace Cocktails.Persistence.Contracts
{
    public interface ICocktailApiGateway
    {
        public Task<CocktailDetails> GetAsync(int id);
        public Task<List<Cocktail>> GetAllByAlcoholAsync(AlcoholType alcoholType);
    }
}