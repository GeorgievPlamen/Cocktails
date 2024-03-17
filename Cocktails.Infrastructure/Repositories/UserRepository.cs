using Cocktails.Application.Interfaces;
using Cocktails.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cocktails.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<User?> AddAsync(User user)
        {
            if (await _userManager.Users.AnyAsync(u => u.Email == user.Email))
                throw new ArgumentException("Email already used");

            var newUser = new IdentityUser
            {
                UserName = user.Name,
                Email = user.Email,
            };

            var result = await _userManager.CreateAsync(newUser, user.Password!);
            if (result.Succeeded == false)
                throw new ArgumentException("Registration failed");

            return await GetUserByEmailAsync(newUser.Email!);
        }

        public async Task<User?> LoginUserAsync(string email, string password)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;

            var result = await _userManager.CheckPasswordAsync(user, password);

            if (result == false)
                return null;

            return await GetUserByEmailAsync(email);
        }

        private async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            User result = new User
            {
                Id = user?.Id.ToString(),
                Name = user?.UserName,
                Email = user?.Email,
            };

            return result;
        }
    }
}