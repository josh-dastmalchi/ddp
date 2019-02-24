using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class RelationshipRemovedEvent : IDomainEvent
    {
        public RelationshipRemovedEvent(Guid relationshipId, Guid eventId)
        {
            RelationshipId = relationshipId;
            EventId = eventId;
        }

        public Guid RelationshipId { get; }
        public Guid EventId { get; }
    }
}