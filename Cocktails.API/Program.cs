using Cocktails.Application;
using Cocktails.Persistence;
using Cocktails.Infrastructure;
using Cocktails.API.Middleware;
using Cocktails.API.GraphQL;
using Cocktails.API.GraphQL.Queries.CocktailsQueries;
using Cocktails.API.GraphQL.Queries.UserQuery;
using Cocktails.API.GraphQL.Base;
using Cocktails.API.GraphQL.Mutations.User;
using Cocktails.API.GraphQL.Mutations.Cocktails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddTypeExtension<UserQuery>()
    .AddTypeExtension<CocktailQueries>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<UserMutations>()
    .AddTypeExtension<CocktailsMutation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:3000");
});

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();
app.MapControllers();

app.Run();
