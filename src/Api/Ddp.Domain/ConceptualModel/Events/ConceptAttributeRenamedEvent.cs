using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class ConceptAttributeRenamedEvent : IDomainEvent
    {
        public ConceptAttributeRenamedEvent(Guid conceptAttributeId, string name, Guid eventId)
        {
            ConceptAttributeId = conceptAttributeId;
            Name = name;
            EventId = eventId;
        }

        public Guid ConceptAttributeId { get; }
        public string Name { get; }
        public Guid EventId { get; }
    }
}