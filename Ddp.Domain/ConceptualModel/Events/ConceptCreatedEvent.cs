using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class ConceptCreatedEvent : IDomainEvent
    {
        public ConceptCreatedEvent(Guid topLevelNounId, string name, Guid eventId)
        {
            TopLevelNounId = topLevelNounId;
            Name = name;
            EventId = eventId;
        }

        public Guid TopLevelNounId { get; }
        public string Name { get; }
        public Guid EventId { get; }
    }
}