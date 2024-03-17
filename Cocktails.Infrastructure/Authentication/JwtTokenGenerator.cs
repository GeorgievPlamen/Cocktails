using Cocktails.Application.Interfaces;

namespace Cocktails.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(string userId, string name)
        {
            throw new NotImplementedException();
        }
    }
}