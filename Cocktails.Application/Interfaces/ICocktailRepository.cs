using Cocktails.Domain;
using Cocktails.Domain.Enums;

namespace Cocktails.Application.Interfaces
{
    public interface ICocktailRepository
    {
        Task<CocktailDetails> GetAsync(int id);
        Task<List<Cocktail>> GetAllByAlcoholAsync(AlcoholType alcoholType);
    }
}