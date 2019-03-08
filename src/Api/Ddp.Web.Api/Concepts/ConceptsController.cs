using System;
using System.Threading.Tasks;
using Ddp.Application;
using Ddp.Application.ConceptualModel;
using Microsoft.AspNetCore.Mvc;

namespace Ddp.Web.Api.Concepts
{
    [ApiController]
    [Route("api/concepts")]
    public class ConceptsController : ControllerBase
    {
        private readonly ICommandHandler<AddConceptCommand> _addConceptCommandHandler;
        private readonly ICommandHandler<RenameConceptCommand> _renameConceptCommandHandler;

        public ConceptsController(ICommandHandler<AddConceptCommand> addConceptCommandHandler,
            ICommandHandler<RenameConceptCommand> renameConceptCommandHandler)
        {
            _addConceptCommandHandler = addConceptCommandHandler;
            _renameConceptCommandHandler = renameConceptCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddConceptRequest request)
        {

            var command = new AddConceptCommand(request.ConceptId, request.Name, request.Description);

            await _addConceptCommandHandler.Handle(command);

            return Ok();
        }

        [HttpPatch]
        [Route("{conceptId}/rename")]
        public async Task<IActionResult> Add([FromRoute]Guid conceptId, [FromBody]RenameConceptRequest request)
        {
            var command = new RenameConceptCommand(conceptId, request.Name);

            await _renameConceptCommandHandler.Handle(command);

            return Ok();
        }
    }
}
