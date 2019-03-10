using System.Collections.Generic;

namespace Ddp.ReadModels.ConceptualModel
{
    public class GetConceptsForDomainReadModel
    {
        public GetConceptsForDomainReadModel()
        {
            Concepts = new List<GetConceptsForDomainReadModelConcept>();
        }

        public List<GetConceptsForDomainReadModelConcept> Concepts { get; set; }
    }
}
