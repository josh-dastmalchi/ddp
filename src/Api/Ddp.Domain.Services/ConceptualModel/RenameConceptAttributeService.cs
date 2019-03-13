using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.ConceptualModel.Concepts;
using Ddp.Domain.ConceptualModel.Repositories;

namespace Ddp.Domain.Services.ConceptualModel
{
    public class RenameConceptAttributeService
    {
        private readonly IConceptAttributeRepository _conceptAttributeRepository;

        public RenameConceptAttributeService(IConceptAttributeRepository conceptAttributeRepository)
        {
            _conceptAttributeRepository = conceptAttributeRepository;
        }

        public async Task Rename(ConceptAttribute conceptAttribute, string newName,  CancellationToken cancellationToken)
        {
            var existing = await _conceptAttributeRepository.GetByConceptAndName(conceptAttribute.ConceptId, newName, cancellationToken);

            if (existing != null && existing.ConceptAttributeId != conceptAttribute.ConceptAttributeId)
            {
                throw new DomainValidationException($"A concept named {newName} already exists.");
            }

            conceptAttribute.Rename(newName);
        }
    }
}