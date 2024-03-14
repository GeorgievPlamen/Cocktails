using MediatR;

namespace Cocktails.Application.FavoriteCocktailsFeature.Queries.FavoriteCocktailsByUser
{
    public class GetFavoriteCocktailsByUserRequest
        : IRequest<List<FavoriteCocktailDTO>>
    {
        public string? UserId { get; }

        public GetFavoriteCocktailsByUserRequest(string? userId)
        {
            UserId = userId;
        }
    }
}