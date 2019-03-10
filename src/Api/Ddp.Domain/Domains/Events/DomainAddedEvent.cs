using System;

namespace Ddp.Domain.Domains.Events
{
    public class DomainAddedEvent : IDomainEvent
    {
        public DomainAddedEvent(Guid domainId, string name, Guid eventId)
        {
            DomainId = domainId;
            Name = name;
            EventId = eventId;
        }

        public Guid DomainId { get; }
        public string Name { get; }
        public Guid EventId { get; }
    }
}