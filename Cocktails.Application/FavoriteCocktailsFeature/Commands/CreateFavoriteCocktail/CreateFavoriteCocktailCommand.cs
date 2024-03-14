using MediatR;

namespace Cocktails.Application.FavoriteCocktailsFeature.Commands.CreateFavoriteCocktail
{
    public class CreateFavoriteCocktailCommand : IRequest<bool>
    {
        public CreateFavoriteCocktailDTO? Cocktail { get; set; }
    }
}