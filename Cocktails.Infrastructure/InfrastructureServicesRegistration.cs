using Cocktails.Infrastructure.APIGateway;
using Cocktails.Infrastructure.Cache;
using Cocktails.Persistence.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Cocktails.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<ICocktailApiGateway, CocktailApiGateway>();
            services.AddScoped<ICocktailsCache, CocktailsCache>();
            services.AddMemoryCache();

            return services;
        }
    }
}