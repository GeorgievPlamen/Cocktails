
namespace Cocktails.Application.FavoriteCocktailsFeature
{
    public class FavoriteCocktailDTO
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? ImageURL { get; set; }
    }
}