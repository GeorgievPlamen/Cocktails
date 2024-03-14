using Microsoft.AspNetCore.Mvc;

namespace Cocktails.API.Controllers.Base
{
    [ApiController]
    [Route("/api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}