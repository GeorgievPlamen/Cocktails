using Cocktails.Domain;

namespace Cocktails.Application.Persistence.Contracts
{
    public interface IFavoriteCocktailsRepository
    {
        Task<FavoriteCocktail> Get(int id);
        Task<List<FavoriteCocktail>> GetAll();
        Task<bool> Add(FavoriteCocktail favorite);
        Task<bool> Delete(FavoriteCocktail favorite);
    }
}