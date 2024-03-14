using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cocktails.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteCocktails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCocktails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FavoriteCocktails",
                columns: new[] { "Id", "DateCreated", "ImageURL", "Name", "UserId" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7854), "https://www.liquor.com/thmb/V5L3hv-w8ph2_RQi_-simg-4Ris=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Frozen-Margarita-1500x1500-hero-191e49b3ab4f4781b93f3cfacac25136.jpg", "Margarita", "tester" },
                    { 101, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7857), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Bloody Mary", "tester" },
                    { 102, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7858), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Test2", "tester" },
                    { 103, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7859), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Bloody Mary", "tester" },
                    { 104, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7859), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Some Drink", "tester" },
                    { 105, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7860), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Fifth one", "tester" },
                    { 106, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7861), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Testing 6th", "tester" },
                    { 107, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7862), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Another Margarita", "tester" },
                    { 108, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7862), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Third Margarita", "tester" },
                    { 109, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7863), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Fourth Margarita", "tester" },
                    { 110, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7864), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Third Bloody Mary", "tester" },
                    { 111, new DateTime(2024, 3, 14, 7, 44, 26, 936, DateTimeKind.Utc).AddTicks(7865), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Final test drink", "111" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteCocktails");
        }
    }
}
