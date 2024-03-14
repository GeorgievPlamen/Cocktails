using System.ComponentModel.DataAnnotations;

namespace Cocktails.Application.FavoriteCocktailsFeature
{
    public class CreateFavoriteCocktailDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string? UserId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? ImageURL { get; set; }
    }
}