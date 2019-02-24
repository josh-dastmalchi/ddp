using System;
using System.Collections.Generic;

namespace Ddp.Domain.ConceptualModel.Relationships
{
    public class RelationshipRole : ValueObject<RelationshipRole>
    {
        public RelationshipRole(Guid conceptId, int? minimumCardinality, int? maximumCardinality)
        {
            ConceptId = conceptId;
            MinimumCardinality = minimumCardinality;
            MaximumCardinality = maximumCardinality;
        }
        
        public Guid ConceptId { get; }
        public int? MinimumCardinality { get; }
        public int? MaximumCardinality { get; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { ConceptId, MinimumCardinality, MaximumCardinality};
        }
    }
}