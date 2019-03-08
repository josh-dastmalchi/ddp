using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain;
using Ddp.Domain.ConceptualModel.Repositories;

namespace Ddp.Application.ConceptualModel
{
    public class RenameConceptCommandHandler : TransactedCommandHandler<RenameConceptCommand>
    {
        private readonly IConceptRepository _conceptRepository;

        public RenameConceptCommandHandler(IConceptRepository conceptRepository)
        {
            _conceptRepository = conceptRepository;
        }

        protected override async Task HandleTransacted(RenameConceptCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            var concept = await _conceptRepository.Get(command.ConceptId, cancellationToken);

            if (concept == null)
            {
                throw new EntityNotFoundException("The requested concept was not found.");
            }

            concept.Rename(command.Name);

            await _conceptRepository.Update(concept);
        }
    }
}
