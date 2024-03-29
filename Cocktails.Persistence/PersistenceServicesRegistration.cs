using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cocktails.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<CocktailsDbContext>(options =>
                options.UseSqlite(
                   config.GetConnectionString("DefaultConnection")
                ));
            services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<CocktailsDbContext>();

            return services;
        }
    }
}