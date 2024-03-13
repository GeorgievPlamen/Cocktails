namespace Cocktails.Domain
{
    public class CocktailDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Alcoholic { get; set; }
        public string? Glass { get; set; }
        public string? Instructions { get; set; }
        public string? ImageURL { get; set; }
        public List<string>? Ingredients { get; set; }
        public List<string>? Measurements { get; set; }
    }
}