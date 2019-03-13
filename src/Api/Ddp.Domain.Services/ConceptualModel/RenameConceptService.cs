using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.ConceptualModel.Concepts;
using Ddp.Domain.ConceptualModel.Repositories;

namespace Ddp.Domain.Services.ConceptualModel
{
    public class RenameConceptService
    {
        private readonly IConceptRepository _conceptRepository;

        public RenameConceptService(IConceptRepository conceptRepository)
        {
            _conceptRepository = conceptRepository;
        }

        public async Task Rename(Concept concept, string newName, CancellationToken cancellationToken)
        {
            var existing = await _conceptRepository.GetByName(newName, cancellationToken);
            if (existing != null && existing.ConceptId != concept.ConceptId)
            {
                throw new DomainValidationException($"A concept named {newName} already exists.");
            }
            concept.Rename(newName);
        }
    }
}
