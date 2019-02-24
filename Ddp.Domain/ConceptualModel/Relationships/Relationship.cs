using System;

namespace Ddp.Domain.ConceptualModel.Relationships
{
    public class Relationship : EventSourcedEntity
    {
        public Relationship(Guid relationshipId, RelationshipRole left, RelationshipRole right, string name,
            string description)
        {

        }
        public Guid RelationshipId { get; private set; }
        public RelationshipRole Left { get; private set; }

        public RelationshipRole Right { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}