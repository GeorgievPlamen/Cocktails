using Cocktails.API.Controllers.Base;
using Cocktails.Application.AuthenticationFeature;
using Cocktails.Application.AuthenticationFeature.Commands;
using Cocktails.Application.AuthenticationFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cocktails.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            var result = await _mediator.Send(new RegisterRequest(register));
            return result == null ?
                BadRequest("Registration failed") :
                Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _mediator.Send(new LoginRequest(loginDTO));
            return result == null ?
                Unauthorized("Email or password is wrong.") :
                Ok(result);
        }
    }
}