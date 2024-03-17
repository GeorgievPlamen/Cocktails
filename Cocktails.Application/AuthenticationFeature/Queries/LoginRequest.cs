using MediatR;

namespace Cocktails.Application.AuthenticationFeature.Queries
{
    public class LoginRequest : IRequest<UserDTO?>
    {
        public LoginDTO Login { get; }
        public LoginRequest(LoginDTO loginDTO)
        {
            Login = loginDTO;
        }
    }
}