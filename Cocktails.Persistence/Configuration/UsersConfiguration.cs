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
                    Id = "ee19ebca-901a-4ce9-a435-6b074db12f9f",
                    UserName = "John",
                    NormalizedUserName = "JOHN",
                    Email = "john@test.com",
                    NormalizedEmail = "JOHN@TEST.COM",
                    PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
                },
                new IdentityUser
                {
                    Id = "a9dc8882-1d14-493a-9e18-2c604d043c8b",
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