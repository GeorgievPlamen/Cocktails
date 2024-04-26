using Cocktails.Application.AuthenticationFeature;
using Cocktails.Application.AuthenticationFeature.Commands;
using Cocktails.Application.FavoriteCocktailsFeature;
using Cocktails.Application.FavoriteCocktailsFeature.Commands.CreateFavoriteCocktail;
using Cocktails.Application.FavoriteCocktailsFeature.Commands.DeleteFavoriteCocktail;
using MediatR;

namespace Cocktails.API.GraphQL;

public class Mutations
{
    public async Task<bool> RemoveFavorites([Service] IMediator mediator, int id)
    {
        return await mediator.Send(new DeleteFavoriteCocktailCommand(id));
    }
    public async Task<bool> AddFavorite([Service] IMediator mediator, CreateFavoriteCocktailDTO cocktail)
    {
        return await mediator.Send(new CreateFavoriteCocktailCommand(cocktail));
    }

    public async Task<UserDTO?> RegisterUser([Service] IMediator mediator, RegisterDTO register)
    {
        return await mediator.Send(new RegisterRequest(register));
    }
}