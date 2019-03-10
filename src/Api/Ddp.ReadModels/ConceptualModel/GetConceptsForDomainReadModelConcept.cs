using System;

namespace Ddp.ReadModels.ConceptualModel
{
    public class GetConceptsForDomainReadModelConcept
    {
        public Guid ConceptId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
