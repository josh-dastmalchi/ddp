using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class ConceptAddedEvent : IDomainEvent
    {
        public ConceptAddedEvent(Guid conceptId, Guid domainId, string name, string description, Guid eventId)
        {
            ConceptId = conceptId;
            DomainId = domainId;
            Name = name;
            Description = description;
            EventId = eventId;
        }

        public Guid ConceptId { get; }
        public Guid DomainId { get; }
        public string Name { get; }
        public string Description { get; }
        public Guid EventId { get; }
    }
}
