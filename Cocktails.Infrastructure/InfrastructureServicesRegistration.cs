using Cocktails.Application.Interfaces;
using Cocktails.Infrastructure.APIGateway;
using Cocktails.Infrastructure.Cache;
using Cocktails.Infrastructure.Interfaces;
using Cocktails.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cocktails.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services)
        {
            services.AddScoped<IFavoriteCocktailsRepository, FavoriteCocktailsRepository>();
            services.AddScoped<ICocktailRepository, CocktailRepository>();
            services.AddHttpClient();
            services.AddScoped<ICocktailApiGateway, CocktailApiGateway>();
            services.AddScoped<ICocktailsCache, CocktailsCache>();
            services.AddMemoryCache();

            return services;
        }
    }
}