using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cocktails.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0190b0a2-e22d-4df8-a025-9a48c52c5e0d", 0, "af07c7b5-71be-4c43-ad8c-30492065208a", "janeTester@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAENUkF2GeXzKpMV5RKCT1rPzNv1eW50FNXAPQ1Bga0ry6Hyy0CY3e/8ICd0CteB/gJw==", null, false, "f1410643-1a3d-457f-a126-8ee2abdd6177", false, "ane" },
                    { "f98c2d37-2efd-47dd-934d-65fda0c54364", 0, "64457363-d57e-4421-86a5-9e696ebfdafa", "johnTester@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEE5yxx2MB+GXw0BcEzHOYSr0+3OB76f7l4XcaaQlsTBhfJ0w6IvclB1grxwuCZNEzw==", null, false, "6806cd9f-6e75-4598-828e-bf75c50270d9", false, "John" }
                });

            migrationBuilder.InsertData(
                table: "FavoriteCocktails",
                columns: new[] { "Id", "DateCreated", "ImageURL", "Name", "UserId" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7275), "https://www.liquor.com/thmb/V5L3hv-w8ph2_RQi_-simg-4Ris=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Frozen-Margarita-1500x1500-hero-191e49b3ab4f4781b93f3cfacac25136.jpg", "Margarita", "tester" },
                    { 101, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7277), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Bloody Mary", "tester" },
                    { 102, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7278), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Test2", "tester" },
                    { 103, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7279), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Bloody Mary", "tester" },
                    { 104, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7280), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Some Drink", "tester" },
                    { 105, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7281), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Fifth one", "tester" },
                    { 106, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7282), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Testing 6th", "tester" },
                    { 107, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7283), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Another Margarita", "tester" },
                    { 108, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7283), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Third Margarita", "tester" },
                    { 109, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7284), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Fourth Margarita", "tester" },
                    { 110, new DateTime(2024, 3, 17, 7, 27, 49, 900, DateTimeKind.Utc).AddTicks(7285), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Third Bloody Mary", "tester" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FavoriteCocktails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
