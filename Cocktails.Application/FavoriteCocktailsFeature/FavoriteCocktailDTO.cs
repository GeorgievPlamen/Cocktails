
using Cocktails.Application.CocktailsFeature;

namespace Cocktails.Application.FavoriteCocktailsFeature
{
    public class FavoriteCocktailDTO
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? UserId { get; set; }
        public CocktailDTO? Cocktail { get; set; }
    }
}