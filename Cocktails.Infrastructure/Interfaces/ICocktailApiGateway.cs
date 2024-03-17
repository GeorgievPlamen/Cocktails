using Cocktails.Domain;
using Cocktails.Domain.Enums;

namespace Cocktails.Infrastructure.Interfaces
{
    public interface ICocktailApiGateway
    {
        public Task<CocktailDetails> GetAsync(int id);
        public Task<List<Cocktail>> GetAllByAlcoholAsync(AlcoholType alcoholType);
    }
}