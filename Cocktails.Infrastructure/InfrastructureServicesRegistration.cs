using System.Text;
using Cocktails.Application.Interfaces;
using Cocktails.Infrastructure.APIGateway;
using Cocktails.Infrastructure.Authentication;
using Cocktails.Infrastructure.Cache;
using Cocktails.Infrastructure.Interfaces;
using Cocktails.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cocktails.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, ConfigurationManager config)
        {
            services.AddScoped<IFavoriteCocktailsRepository, FavoriteCocktailsRepository>();
            services.AddScoped<ICocktailRepository, CocktailRepository>();
            services.AddScoped<ICocktailApiGateway, CocktailApiGateway>();
            services.AddScoped<ICocktailsCache, CocktailsCache>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddHttpClient();
            services.AddMemoryCache();

            services.Configure<JwtSettings>(config.GetSection("JwtSettings"));
            var jwtSettings = new JwtSettings();
            config.Bind("jwtSettings", jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(opt =>
               {
                   var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Secret"]!));
                   opt.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       ValidateLifetime = true,
                       ValidIssuer = jwtSettings.Issuer,
                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(jwtSettings.Secret!))
                   };
               });

            return services;
        }
    }
}