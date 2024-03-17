using AutoMapper;
using Cocktails.Application.Interfaces;
using Cocktails.Domain;
using MediatR;

namespace Cocktails.Application.AuthenticationFeature.Commands
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, UserDTO?>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public RegisterRequestHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }
        public async Task<UserDTO?> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            if (request.RegisterDTO == null || request.RegisterDTO.Email == null)
                throw new ArgumentNullException(nameof(request.RegisterDTO));

            var user = new User
            {
                Name = request.RegisterDTO.Name,
                Email = request.RegisterDTO.Email,
                Password = request.RegisterDTO.Password
            };

            var registerResult = await _userRepository.AddAsync(user);
            if (registerResult == null)
                return null;

            var result = _mapper.Map<UserDTO>(registerResult);
            if (result.Id == null || result.Name == null)
                return null;

            result.Token = _jwtTokenGenerator.GenerateToken(result.Id, result.Name);

            return result;
        }
    }
}