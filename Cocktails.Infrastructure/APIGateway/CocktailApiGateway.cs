using System.Text.Json;
using Cocktails.Application.Persistence.Contracts.Enums;
using Cocktails.Domain;
using Cocktails.Infrastructure.APIGateway.Models;
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
            var responseMsg = await client.SendAsync(new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={alcoholType}")
            });

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            string responseBody = await responseMsg.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<DrinksResponse>(responseBody, options)?.Drinks;
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            var result = new List<Cocktail>();

            foreach (Drink drink in response)
            {
                result.Add(new Cocktail
                {
                    Id = Convert.ToInt32(drink.IdDrink),
                    Name = drink.StrDrink,
                    ImageURL = drink.StrDrinkThumb
                });
            }

            return result;
        }

        public async Task<CocktailDetails> GetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.SendAsync(new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}")
            });

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            string responseBody = await responseMsg.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<DrinkDetails>(responseBody, options)?.Drinks?[0];
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            var result = new CocktailDetails
            {
                Id = Convert.ToInt32(response.IdDrink),
                Name = response.StrDrink,
                Alcoholic = response.StrAlcoholic,
                Glass = response.StrGlass,
                Instructions = response.StrInstructions,
                ImageURL = response.StrDrinkThumb,
                Ingredients = new List<string>(),
                Measurements = new List<string>()
            };

            var ingredientProperties = typeof(Details).GetProperties()
                 .Where(p => p.Name.StartsWith("StrIngredient") && p.GetValue(response) != null);

            var measureProperties = typeof(Details).GetProperties()
                .Where(p => p.Name.StartsWith("StrMeasure") && p.GetValue(response) != null);

            foreach (var ingredientProperty in ingredientProperties)
            {
                result.Ingredients.Add((string)ingredientProperty.GetValue(response)!);
            }

            foreach (var measureProperty in measureProperties)
            {
                result.Measurements.Add((string)measureProperty.GetValue(response)!);
            }

            return result;
        }
    }
}