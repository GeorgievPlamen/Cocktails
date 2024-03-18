using Cocktails.API.Controllers.Base;
using Cocktails.Application.CocktailsFeature.Queries.CockatilDetails;
using Cocktails.Application.CocktailsFeature.Queries.ListOfCockatilsByAlcohol;
using Cocktails.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cocktails.API.Controllers
{
    [Authorize]
    public class CocktailController : BaseController
    {
        private readonly IMediator _mediator;
        public CocktailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetCocktailDetailsRequest(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetByAlcohol(AlcoholType alcoholType)
        {
            return Ok(await _mediator.Send(new ListByAlcoholRequest(alcoholType)));
        }
    }
}