using Cocktails.Domain;

namespace Cocktails.Application.Persistence.Contracts
{
    public interface IFavoriteCocktailsRepository
    {
        Task<FavoriteCocktail> Get(int id);
        Task<List<FavoriteCocktail>> GetAllByUser(string userId);
        Task<bool> Add(FavoriteCocktail entity);
        Task<bool> Delete(FavoriteCocktail entity);
    }
}