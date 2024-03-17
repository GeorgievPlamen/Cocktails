using Cocktails.Domain;

namespace Cocktails.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> LoginUserAsync(string email, string password);
        Task<User> AddAsync(User user);
    }
}