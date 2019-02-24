using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class ConceptAttributeAddedEvent : IDomainEvent
    {
        public ConceptAttributeAddedEvent(Guid conceptAttributeId, Guid conceptId, string name, Guid eventId)
        {
            ConceptAttributeId = conceptAttributeId;
            ConceptId = conceptId;
            Name = name;
            EventId = eventId;
        }

        public Guid ConceptAttributeId { get; }
        public Guid ConceptId { get; }
        public string Name { get; }
        public Guid EventId { get; }
    }
}