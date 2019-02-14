using System;

namespace Ddp.Domain.Events
{
    public class EntityTypeRenamedEvent : IDomainEvent
    {
        public EntityTypeRenamedEvent(Guid eventId, string name)
        {
            EventId = eventId;
            Name = name;
        }

        public string Name { get; }
        public Guid EventId { get; }
    }
}