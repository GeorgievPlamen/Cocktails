using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cocktails.Persistence.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            builder.HasData(
                new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "John",
                    Email = "johnTester@test.com",
                    PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
                },
                new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "ane",
                    Email = "janeTester@test.com",
                    PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
                }
            );
        }
    }
}