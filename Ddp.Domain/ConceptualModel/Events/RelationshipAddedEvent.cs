using System;
using System.Collections.Generic;
using System.Text;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class RelationshipAddedEvent : IDomainEvent
    {
        public RelationshipAddedEvent(Guid relationshipId, Guid eventId)
        {
            RelationshipId = relationshipId;
            EventId = eventId;
        }

        public Guid RelationshipId { get; }
        public Guid EventId { get; }
    }
}
