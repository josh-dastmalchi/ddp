using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.ConceptualModel.Concepts;
using Ddp.Domain.ConceptualModel.Repositories;

namespace Ddp.Domain.Services.ConceptualModel
{
    public class AddConceptAttributeService
    {
        private readonly IConceptAttributeRepository _conceptAttributeRepository;

        public AddConceptAttributeService(IConceptAttributeRepository conceptAttributeRepository)
        {
            _conceptAttributeRepository = conceptAttributeRepository;
        }

        public async Task Add(ConceptAttribute conceptAttribute, CancellationToken cancellationToken)
        {
            var existing = _conceptAttributeRepository.GetByConceptAndName(conceptAttribute.ConceptId,
                conceptAttribute.Name, cancellationToken);

            if (existing != null)
            {
                throw new DomainValidationException($"A concept attribute named {conceptAttribute.Name} already exists on that concept.");
            }

            await _conceptAttributeRepository.Create(conceptAttribute, cancellationToken);
        }
    }
}