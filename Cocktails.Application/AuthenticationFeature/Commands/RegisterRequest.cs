using MediatR;

namespace Cocktails.Application.AuthenticationFeature.Commands
{
    public class RegisterRequest : IRequest<UserDTO?>
    {
        public RegisterDTO RegisterDTO { get; }
        public RegisterRequest(RegisterDTO registerDTO)
        {
            RegisterDTO = registerDTO;
        }
    }
}