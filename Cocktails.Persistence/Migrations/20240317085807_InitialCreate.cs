using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cocktails.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { "a9dc8882-1d14-493a-9e18-2c604d043c8b", 0, "9640df15-11ab-493d-8823-b1cdbc65ea06", "jane@test.com", false, false, null, "JANE@TEST.COM", "JANE", "AQAAAAIAAYagAAAAEDz7hxDANpwCPAzx96ElUl62b+0IrikjZjAYYLpEFYmNReNhfBhaM++CWeVxN3UXqg==", null, false, "57f1215e-97b8-46b5-8846-aaebb6e26c66", false, "Jane" },
                    { "ee19ebca-901a-4ce9-a435-6b074db12f9f", 0, "31179899-eabc-4f85-bd46-4c36021f0e2d", "john@test.com", false, false, null, "JOHN@TEST.COM", "JOHN", "AQAAAAIAAYagAAAAEN+qs11gZb4JWgvp1wCUVFv6lvykvK5jQUD+qQazni0N9RAW8hOhHUL0SC5RTlQuyg==", null, false, "8568c1a6-db21-48a7-9ae3-ee66e2215100", false, "John" }
                });

            migrationBuilder.InsertData(
                table: "FavoriteCocktails",
                columns: new[] { "Id", "DateCreated", "ImageURL", "Name", "UserId" },
                values: new object[,]
                {
                    { 100, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9952), "https://www.liquor.com/thmb/V5L3hv-w8ph2_RQi_-simg-4Ris=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Frozen-Margarita-1500x1500-hero-191e49b3ab4f4781b93f3cfacac25136.jpg", "Margarita", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 101, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9955), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Bloody Mary", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 102, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9956), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Test2", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 103, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9957), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Bloody Mary", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 104, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9958), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Some Drink", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 105, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9958), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Fifth one", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 106, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9959), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Testing 6th", "ee19ebca-901a-4ce9-a435-6b074db12f9f" },
                    { 107, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9960), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Another Margarita", "a9dc8882-1d14-493a-9e18-2c604d043c8b" },
                    { 108, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9961), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Third Margarita", "a9dc8882-1d14-493a-9e18-2c604d043c8b" },
                    { 109, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9962), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Fourth Margarita", "a9dc8882-1d14-493a-9e18-2c604d043c8b" },
                    { 110, new DateTime(2024, 3, 17, 8, 58, 7, 368, DateTimeKind.Utc).AddTicks(9963), "https://img.jamieoliver.com/jamieoliver/recipe-database/oldImages/large/1202_1_1439206245.jpg?tr=w-800,h-1066", "Third Bloody Mary", "a9dc8882-1d14-493a-9e18-2c604d043c8b" }
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
