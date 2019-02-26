using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class RelationshipAddedEvent : IDomainEvent
    {
        public RelationshipAddedEvent(Guid relationshipId, string name, Guid leftSideConceptId, Guid rightSideConceptId, Guid eventId)
        {
            RelationshipId = relationshipId;
            Name = name;
            LeftSideConceptId = leftSideConceptId;
            RightSideConceptId = rightSideConceptId;
            EventId = eventId;
        }

        public Guid RelationshipId { get; }
        public string Name { get; }
        public Guid LeftSideConceptId { get; }
        public Guid RightSideConceptId { get; }
        public Guid EventId { get; }
    }
}