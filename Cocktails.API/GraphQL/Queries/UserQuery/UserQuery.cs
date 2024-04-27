using Cocktails.API.GraphQL.Base;
using Cocktails.Application.AuthenticationFeature;
using Cocktails.Application.AuthenticationFeature.Queries;
using MediatR;

namespace Cocktails.API.GraphQL.Queries.UserQuery;

[ExtendObjectType<Query>]
public class UserQuery
{
    public async Task<UserDTO?> Login([Service] IMediator mediator, LoginDTO loginDTO)
    {
        return await mediator.Send(new LoginRequest(loginDTO));
    }
}