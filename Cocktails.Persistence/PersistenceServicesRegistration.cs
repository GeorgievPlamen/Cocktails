using Cocktails.Application.Persistence.Contracts;
using Cocktails.Persistence.Repositories;
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
            services.AddScoped<IFavoriteCocktailsRepository, FavoriteCocktailsRepository>();
            services.AddScoped<ICocktailRepository, CocktailRepository>();

            return services;
        }
    }
}