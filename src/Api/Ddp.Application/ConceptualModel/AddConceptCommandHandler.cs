using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.ConceptualModel.Concepts;
using Ddp.Domain.ConceptualModel.Repositories;

namespace Ddp.Application.ConceptualModel
{
    public class AddConceptCommandHandler : TransactedCommandHandler<AddConceptCommand>
    {
        private readonly IConceptRepository _conceptRepository;

        public AddConceptCommandHandler(IConceptRepository conceptRepository)
        {
            _conceptRepository = conceptRepository;
        }

        protected override async Task HandleTransacted(AddConceptCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            var concept = new Concept(command.ConceptId, command.Name, command.Description);
            await _conceptRepository.Create(concept, cancellationToken);
        }
    }
}
