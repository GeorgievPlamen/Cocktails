using Cocktails.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cocktails.Persistence.Configuration
{
    public class FavoriteCocktailsConfiguration : IEntityTypeConfiguration<FavoriteCocktail>
    {
        public void Configure(EntityTypeBuilder<FavoriteCocktail> builder)
        {
            builder.HasData(
                new FavoriteCocktail
                {
                    Id = 100,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Margarita",
                    ImageURL = "https://www.liquor.com/thmb/V5L3hv-w8ph2_RQi_-simg-4Ris=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Frozen-Margarita-1500x1500-hero-191e49b3ab4f4781b93f3cfacac25136.jpg"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 101,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Bloody Mary",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 102,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Test2",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 103,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Bloody Mary",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 104,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Some Drink",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 105,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Fifth one",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 106,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Testing 6th",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 107,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Another Margarita",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 108,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Third Margarita",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 109,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Fourth Margarita",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 110,
                    DateCreated = DateTime.UtcNow,
                    UserId = "tester",
                    Name = "Third Bloody Mary",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                ,
                new FavoriteCocktail
                {
                    Id = 111,
                    DateCreated = DateTime.UtcNow,
                    UserId = "111",
                    Name = "Final test drink",
                    ImageURL = "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066"
                }
                );
        }
    }
}