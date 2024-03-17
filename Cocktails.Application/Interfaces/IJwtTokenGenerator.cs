namespace Cocktails.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userId, string name);
    }
}