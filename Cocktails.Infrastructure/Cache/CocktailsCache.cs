using Cocktails.Domain;
using Cocktails.Domain.Enums;
using Cocktails.Infrastructure.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Cocktails.Infrastructure.Cache
{
    public class CocktailsCache : ICocktailsCache
    {
        private readonly IMemoryCache _cache;
        public CocktailsCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<CocktailDetails?> GetAsync(int id)
        {
            var result = (CocktailDetails?)_cache.Get(id);
            await Task.CompletedTask;
            return result;
        }

        public async Task AddAsync(CocktailDetails cocktail, TimeSpan expirationTime)
        {
            _cache.Set(cocktail.Id, cocktail, expirationTime);
            await Task.CompletedTask;
        }

        public async Task<List<Cocktail>?> GetAllByAlcoholAsync(AlcoholType alcoholType)
        {
            var result = (List<Cocktail>?)_cache.Get(alcoholType);
            await Task.CompletedTask;
            return result;
        }

        public async Task AddAllByAlcoholAsync(AlcoholType alcoholType, List<Cocktail> cocktails, TimeSpan expirationTime)
        {
            _cache.Set(alcoholType, cocktails, expirationTime);
            await Task.CompletedTask;
        }
    }
}