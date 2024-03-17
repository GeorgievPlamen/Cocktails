using Cocktails.Application.Interfaces;
using Cocktails.Domain;

namespace Cocktails.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> LoginUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}