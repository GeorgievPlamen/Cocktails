using Cocktails.API.Controllers.Base;
using Cocktails.Application.FavoriteCocktailsFeature;
using Cocktails.Application.FavoriteCocktailsFeature.Commands.CreateFavoriteCocktail;
using Cocktails.Application.FavoriteCocktailsFeature.Commands.DeleteFavoriteCocktail;
using Cocktails.Application.FavoriteCocktailsFeature.Queries.FavoriteCocktailsByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cocktails.API.Controllers
{
    public class FavoriteCocktailsController : BaseController
    {
        private readonly IMediator _mediator;
        public FavoriteCocktailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Will get username from logged in users
        //Will require authentication
        [HttpGet]
        public async Task<ActionResult<List<FavoriteCocktailDTO>>> GetFavorites()
        {
            string username = "tester";
            var favorites = await _mediator.Send(new GetFavoriteCocktailsByUserRequest(username));
            return favorites;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateFavoriteCocktailDTO cocktail)
        {
            var result = await _mediator.Send(new CreateFavoriteCocktailCommand(cocktail));
            return result ? Ok() : BadRequest("Creation failed, try again.");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteFavoriteCocktailCommand(id));
            return result ? Ok() : BadRequest("Deletion failed, try again");
        }
    }
}