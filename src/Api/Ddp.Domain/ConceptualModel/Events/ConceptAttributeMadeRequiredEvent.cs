using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class ConceptAttributeMadeRequiredEvent : IDomainEvent
    {
        public ConceptAttributeMadeRequiredEvent(Guid conceptAttributeId, Guid eventId)
        {
            ConceptAttributeId = conceptAttributeId;
            EventId = eventId;
        }

        public Guid ConceptAttributeId { get; }
        public Guid EventId { get; }
    }
}