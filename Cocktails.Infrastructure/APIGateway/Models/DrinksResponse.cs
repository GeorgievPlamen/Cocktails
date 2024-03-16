namespace Cocktails.Infrastructure.APIGateway.Models
{
    internal class DrinksResponse
    {
        public Drink[]? Drinks { get; set; }
    }

    internal class Drink
    {
        public string? StrDrink { get; set; }
        public string? StrDrinkThumb { get; set; }
        public string? IdDrink { get; set; }
    }
}