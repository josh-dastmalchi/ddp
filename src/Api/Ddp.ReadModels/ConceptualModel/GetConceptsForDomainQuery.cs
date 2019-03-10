using System;

namespace Ddp.ReadModels.ConceptualModel
{
    public class GetConceptsForDomainQuery : IQuery
    {
        public GetConceptsForDomainQuery(Guid domainId)
        {
            DomainId = domainId;
        }

        public Guid DomainId { get; }
    }
}
