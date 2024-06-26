using Cocktails.API.GraphQL.Base;
using Cocktails.Application.FavoriteCocktailsFeature;
using Cocktails.Application.FavoriteCocktailsFeature.Commands.CreateFavoriteCocktail;
using Cocktails.Application.FavoriteCocktailsFeature.Commands.DeleteFavoriteCocktail;
using MediatR;

namespace Cocktails.API.GraphQL.Mutations.Cocktails;

[ExtendObjectType<Mutation>]
public class CocktailsMutation
{
    public async Task<bool> RemoveFavorites([Service] IMediator mediator, int id)
    {
        return await mediator.Send(new DeleteFavoriteCocktailCommand(id));
    }
    public async Task<bool> AddFavorite([Service] IMediator mediator, CreateFavoriteCocktailDTO cocktail)
    {
        return await mediator.Send(new CreateFavoriteCocktailCommand(cocktail));
    }
}