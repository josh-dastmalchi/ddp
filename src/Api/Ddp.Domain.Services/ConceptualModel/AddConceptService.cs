using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.ConceptualModel.Concepts;
using Ddp.Domain.ConceptualModel.Repositories;

namespace Ddp.Domain.Services.ConceptualModel
{
    public class AddConceptService
    {
        private readonly IConceptRepository _conceptRepository;

        public AddConceptService(IConceptRepository conceptRepository)
        {
            _conceptRepository = conceptRepository;
        }
        public async Task Add(Concept concept, CancellationToken cancellationToken = default(CancellationToken))
        {
            var existing = await _conceptRepository.GetByName(concept.Name, cancellationToken);
            if (existing != null)
            {
                throw new DomainValidationException($"A concept named {concept.Name} already exists.");
            }

            await _conceptRepository.Create(concept, cancellationToken);
        }
    }
}