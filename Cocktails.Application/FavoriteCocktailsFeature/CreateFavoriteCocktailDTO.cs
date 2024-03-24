using System.ComponentModel.DataAnnotations;

namespace Cocktails.Application.FavoriteCocktailsFeature
{
    public class CreateFavoriteCocktailDTO
    {
        [Required]
        public int CocktailId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? ImageURL { get; set; }
    }
}