using System.Threading.Tasks;
using Ddp.Application;
using Ddp.Application.Domains;
using Ddp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Ddp.Web.Api.Domains
{
    [Route("api/domains")]
    [ApiController]
    public class DomainsController : ControllerBase
    {
        private readonly ICommandHandler<AddDomainCommand> _addDomainCommandHandler;

        public DomainsController(ICommandHandler<AddDomainCommand> addDomainCommandHandler)
        {
            _addDomainCommandHandler = addDomainCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDomainRequest request)
        {
            var id = GuidComb.Generate();

            var command = new AddDomainCommand(id, request.Name);

            await _addDomainCommandHandler.Handle(command);

            return Ok(id);
        }
    }
}