using System;

namespace Ddp.Domain.ConceptualModel.Relationships
{
    public class Relationship
    {
        public Guid RelationshipId { get; set; }
        public Guid LeftSideConceptId { get; set; }
        public Guid RightSideConceptId { get; set; }

        public int? LeftSideMinimumCardinality { get; set; }
        public int? LeftSideMaximumCardinality { get; set; }

        public int? RightSideMinimumCardinality { get; set; }
        public int? RightSideMaximumCardinality { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}