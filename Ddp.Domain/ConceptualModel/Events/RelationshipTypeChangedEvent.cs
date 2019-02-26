using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class RelationshipTypeChangedEvent : IDomainEvent
    {
        public RelationshipTypeChangedEvent(Guid relationshipId, string relationshipType, Guid eventId)
        {
            RelationshipId = relationshipId;
            RelationshipType = relationshipType;
            EventId = eventId;
        }
        public Guid RelationshipId { get; }
        public string RelationshipType { get; }
        public Guid EventId { get; }
    }
}
