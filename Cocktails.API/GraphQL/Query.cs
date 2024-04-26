using System.Security.Claims;
using Cocktails.Application.AuthenticationFeature;
using Cocktails.Application.AuthenticationFeature.Queries;
using Cocktails.Application.CocktailsFeature;
using Cocktails.Application.CocktailsFeature.Queries.CockatilDetails;
using Cocktails.Application.CocktailsFeature.Queries.ListOfCockatilsByAlcohol;
using Cocktails.Application.FavoriteCocktailsFeature;
using Cocktails.Application.FavoriteCocktailsFeature.Queries.FavoriteCocktailsByUser;
using Cocktails.Domain.Enums;
using HotChocolate.Authorization;
using MediatR;

namespace Cocktails.API.GraphQL;

public class Query
{
    public async Task<UserDTO?> Login([Service] IMediator mediator, LoginDTO loginDTO)
    {
        return await mediator.Send(new LoginRequest(loginDTO));
    }
    public async Task<CocktailDetailsDTO> GetById([Service] IMediator mediator, int id)
    {
        return await mediator.Send(new GetCocktailDetailsRequest(id));
    }
    [UsePaging]
    [Authorize]
    public async Task<List<CocktailDTO>> GetByAlcohol([Service] IMediator mediator, AlcoholType alcoholType, ClaimsPrincipal? claimsPrincipal)
    {
        return await mediator.Send(new ListByAlcoholRequest(alcoholType));
    }

    public async Task<List<FavoriteCocktailDTO>> GetFavorites([Service] IMediator mediator, string userId)
    {
        return await mediator.Send(new GetFavoriteCocktailsByUserRequest(userId));
    }
}