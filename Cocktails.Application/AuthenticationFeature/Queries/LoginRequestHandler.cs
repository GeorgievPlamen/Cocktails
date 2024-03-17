using AutoMapper;
using Cocktails.Application.Interfaces;
using MediatR;

namespace Cocktails.Application.AuthenticationFeature.Queries
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, UserDTO?>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public LoginRequestHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }
        public async Task<UserDTO?> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            if (request.Login.Email == null || request.Login.Password == null)
                throw new ArgumentNullException();

            var user = await _userRepository.LoginUserAsync(request.Login.Email, request.Login.Password);

            if (user == null || user.Id == null || user.Name == null)
                return null;

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Name);

            var result = _mapper.Map<UserDTO>(user);
            result.Token = token;

            return result;
        }
    }
}