using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class ConceptRemovedEvent : IDomainEvent
    {
        public ConceptRemovedEvent(Guid conceptId, Guid eventId)
        {
            ConceptId = conceptId;
            EventId = eventId;
        }

        public Guid ConceptId { get; }
        public Guid EventId { get; }
    }
}
