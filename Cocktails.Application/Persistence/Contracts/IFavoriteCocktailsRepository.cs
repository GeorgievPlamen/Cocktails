using Cocktails.Domain;

namespace Cocktails.Application.Persistence.Contracts
{
    public interface IFavoriteCocktailsRepository
    {
        Task<FavoriteCocktail> GetAsync(int id);
        Task<List<FavoriteCocktail>> GetAllByUserAsync(string userId);
        Task<bool> AddAsync(FavoriteCocktail entity);
        Task<bool> DeleteAsync(FavoriteCocktail entity);
    }
}