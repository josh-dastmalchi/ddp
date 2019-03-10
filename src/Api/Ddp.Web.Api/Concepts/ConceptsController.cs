using System;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Application;
using Ddp.Application.ConceptualModel;
using Ddp.ReadModels;
using Ddp.ReadModels.ConceptualModel;
using Microsoft.AspNetCore.Mvc;

namespace Ddp.Web.Api.Concepts
{
    [ApiController]
    [Route("api/concepts")]
    public class ConceptsController : ControllerBase
    {
        private readonly IQueryHandler<GetConceptsForDomainQuery, GetConceptsForDomainReadModel> _getConceptsForDomainQueryHandler;
        private readonly ICommandHandler<AddConceptCommand> _addConceptCommandHandler;
        private readonly ICommandHandler<RenameConceptCommand> _renameConceptCommandHandler;

        public ConceptsController(
            IQueryHandler<GetConceptsForDomainQuery, GetConceptsForDomainReadModel> getConceptsForDomainQueryHandler,
            ICommandHandler<AddConceptCommand> addConceptCommandHandler,
            ICommandHandler<RenameConceptCommand> renameConceptCommandHandler)
        {
            _getConceptsForDomainQueryHandler = getConceptsForDomainQueryHandler;
            _addConceptCommandHandler = addConceptCommandHandler;
            _renameConceptCommandHandler = renameConceptCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAtDomain(Guid domainId, CancellationToken cancellationToken)
        {
            var query = new GetConceptsForDomainQuery(domainId);

            var readModels = await _getConceptsForDomainQueryHandler.Handle(query, cancellationToken);

            return Ok(readModels);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddConceptRequest request)
        {
            var command = new AddConceptCommand(request.ConceptId, request.DomainId,request.Name, request.Description);

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