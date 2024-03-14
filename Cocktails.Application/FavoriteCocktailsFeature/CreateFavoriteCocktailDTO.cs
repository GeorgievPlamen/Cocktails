using System.ComponentModel.DataAnnotations;
using Cocktails.Application.Common;

namespace Cocktails.Application.FavoriteCocktailsFeature
{
    public class CreateFavoriteCocktailDTO
    {
        [Required]
        public string? UserId { get; set; }
        [Required]
        public CocktailDTO? Cocktail { get; set; }
    }
}