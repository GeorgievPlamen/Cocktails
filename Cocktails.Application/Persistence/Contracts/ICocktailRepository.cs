using Cocktails.Application.Persistence.Contracts.Enums;
using Cocktails.Domain;

namespace Cocktails.Application.Persistence.Contracts
{
    public interface ICocktailRepository
    {
        Task<CocktailDetails> GetAsync(int id);
        Task<List<Cocktail>> GetAllByAlcoholAsync(AlcoholType alcoholType);
    }
}