using Cocktails.API.GraphQL.Base;
using Cocktails.Application.AuthenticationFeature;
using Cocktails.Application.AuthenticationFeature.Commands;
using MediatR;

namespace Cocktails.API.GraphQL.Mutations.User;

[ExtendObjectType<Mutation>]
public class UserMutations
{
    public async Task<UserDTO?> RegisterUser([Service] IMediator mediator, RegisterDTO register)
    {
        return await mediator.Send(new RegisterRequest(register));
    }
}