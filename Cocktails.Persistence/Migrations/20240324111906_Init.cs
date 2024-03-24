using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cocktails.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    CocktailId = table.Column<int>(type: "INTEGER", nullable: false),
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
                    { "a9dc8882-1d14-493a-9e18-2c604d043c8b", 0, "c201f609-8bae-4593-bc84-ddcb337c5e91", "jane@test.com", false, false, null, "JANE@TEST.COM", "JANE", "AQAAAAIAAYagAAAAEFurvpus4koap3XJ+hgApBW0ldQQWgyhogI7NYKeK3S+m/MzBInK4LMtKueiIOxp5A==", null, false, "86e5503d-e6eb-40a3-99b6-a0549da71976", false, "Jane" },
                    { "ee19ebca-901a-4ce9-a435-6b074db12f9f", 0, "c97d323f-1a88-4615-a24a-c5275e29449c", "john@test.com", false, false, null, "JOHN@TEST.COM", "JOHN", "AQAAAAIAAYagAAAAECHR/9NuWnF7y4CPK5SlpKpsO3uP842b1V0JMY3HBJjBaASUc+yq9O1uAxqW0paogg==", null, false, "dfe41b09-9f88-4a6b-aaeb-5ac575983715", false, "John" }
                });

            migrationBuilder.InsertData(
                table: "FavoriteCocktails",
                columns: new[] { "Id", "CocktailId", "DateCreated", "ImageURL", "Name", "UserId" },
                values: new object[,]
                {
                    { 100, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5814), "https://www.liquor.com/thmb/V5L3hv-w8ph2_RQi_-simg-4Ris=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Frozen-Margarita-1500x1500-hero-191e49b3ab4f4781b93f3cfacac25136.jpg", "Margarita", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 101, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5823), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Bloody Mary", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 102, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5825), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Test2", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 103, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5826), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Bloody Mary", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 104, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5826), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Some Drink", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 105, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5827), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Fifth one", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 106, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5828), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Testing 6th", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 107, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5829), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Another Margarita", "a9dc8882-1d14-493a-9e18-2c604d043c8b" },
                    { 108, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5830), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Third Margarita", "a9dc8882-1d14-493a-9e18-2c604d043c8b" },
                    { 109, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5831), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Fourth Margarita", "a9dc8882-1d14-493a-9e18-2c604d043c8b" },
                    { 110, 111, new DateTime(2024, 3, 24, 11, 19, 5, 356, DateTimeKind.Utc).AddTicks(5832), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Third Bloody Mary", "a9dc8882-1d14-493a-9e18-2c604d043c8b" }
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
