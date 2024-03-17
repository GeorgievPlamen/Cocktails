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
                    NormalizedUserName = "JOHN",
                    Email = "john@test.com",
                    NormalizedEmail = "JOHN@TEST.COM",
                    PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
                },
                new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Jane",
                    NormalizedUserName = "JANE",
                    Email = "jane@test.com",
                    NormalizedEmail = "JANE@TEST.COM",
                    PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
                }
            );
        }
    }
}