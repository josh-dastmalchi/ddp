using System;
using Ddp.Domain.ConceptualModel.Events;

namespace Ddp.Domain.ConceptualModel.Relationships
{
    public class Relationship : EventSourcedEntity
    {
        public Relationship(Guid relationshipId, string name, Guid leftSideConceptId, Guid rightSideConceptId)
        {
            Apply(new RelationshipAddedEvent(relationshipId, name, leftSideConceptId, rightSideConceptId,
                GuidComb.Generate()));
        }

        public Guid RelationshipId { get; private set; }
        public string Name { get; private set; }
        public string RelationshipType { get; private set; }
        public bool IsActive { get; private set; }

        public Guid LeftSideConceptId { get; private set; }
        public Guid RightSideConceptId { get; private set; }

        public Cardinality Cardinality { get; private set; }

        public void Rename(string newName)
        {
            Apply(new RelationshipRenamedEvent(RelationshipId, newName, GuidComb.Generate()));
        }

        public void ChangeRelationshipType(string newDescription)
        {
            Apply(new RelationshipTypeChangedEvent(RelationshipId, newDescription, GuidComb.Generate()));
        }

        protected void When(RelationshipAddedEvent @event)
        {
            RelationshipId = @event.RelationshipId;
            Name = @event.Name;
            LeftSideConceptId = @event.LeftSideConceptId;
            RightSideConceptId = @event.RightSideConceptId;
            Cardinality = Cardinality.OneToOne;
            IsActive = true;
        }

        protected void When(RelationshipRemovedEvent @event)
        {
            IsActive = false;
        }

        protected void When(RelationshipTypeChangedEvent @event)
        {
            RelationshipType = @event.RelationshipType;
        }

        protected void When(RelationshipRenamedEvent @event)
        {
            Name = @event.Name;
        }
    }
}