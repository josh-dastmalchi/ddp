using Microsoft.AspNetCore.Mvc;

namespace Ddp.Web.Api.Api
{
    [Route("api/entityTypes")]
    [ApiController]
    public class EntityTypesController : ControllerBase
    {
        [Route("")]
        public IActionResult Hmm()
        {
            return Ok("hurray");
        }

    }
}