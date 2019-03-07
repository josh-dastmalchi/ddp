using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class ConceptDescriptionChangedEvent : IDomainEvent
    {
        public ConceptDescriptionChangedEvent(Guid conceptId, string description, Guid eventId)
        {
            ConceptId = conceptId;
            Description = description;
            EventId = eventId;
        }

        public Guid ConceptId { get; }
        public string Description { get; }
        public Guid EventId { get; }
    }
}