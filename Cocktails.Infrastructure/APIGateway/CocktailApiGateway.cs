using System.Text.Json;
using System.Text.Json.Nodes;
using Cocktails.Application.Persistence.Contracts.Enums;
using Cocktails.Domain;
using Cocktails.Persistence.Contracts;

namespace Cocktails.Infrastructure.APIGateway
{
    public class CocktailApiGateway : ICocktailApiGateway
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CocktailApiGateway(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Cocktail>> GetAllByAlcoholAsync(AlcoholType alcoholType)
        {
            var client = _httpClientFactory.CreateClient();
            var alcohol = alcoholType.ToString();
            var responseMsg = await client.SendAsync(new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={alcohol}")
            });

            string responseBody = await responseMsg.Content.ReadAsStringAsync();
            Dictionary<string, object>? responseDict = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody);
            //TODO map respondeDict to List of cocktails
            return new List<Cocktail>();
        }

        public Task<CocktailDetails> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}