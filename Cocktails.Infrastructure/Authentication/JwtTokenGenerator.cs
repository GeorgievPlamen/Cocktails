using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cocktails.Application.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cocktails.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtOptions;
        public JwtTokenGenerator(IOptions<JwtSettings> options)
        {
            _jwtOptions = options.Value;
        }
        public string GenerateToken(string userId, string name)
        {
            if (_jwtOptions.Secret == null)
                throw new ArgumentNullException("Jwt key is null");

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtOptions.Secret)),
                    SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Name, name),
            };

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                expires: DateTime.Now.AddMinutes(_jwtOptions.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}