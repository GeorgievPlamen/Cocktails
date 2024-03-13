using Cocktails.Application.Persistence.Contracts.Enums;
using Cocktails.Domain;

namespace Cocktails.Application.Persistence.Contracts
{
    public interface ICocktailRepository
    {
        Task<CocktailDetails> Get(int id);
        Task<List<Cocktail>> GetAllByAlcohol(AlcoholType alcoholType);
    }
}