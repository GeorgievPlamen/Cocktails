using MediatR;

namespace Cocktails.Application.FavoriteCocktailsFeature.Commands.DeleteFavoriteCocktail
{
    public class DeleteFavoriteCocktailCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteFavoriteCocktailCommand(int id)
        {
            Id = id;
        }
    }
}