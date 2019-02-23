using System;

namespace Ddp.Domain.EntityRelationshipModel.Events
{
    public class EntityTypeRenamedEvent : IDomainEvent
    {
        public EntityTypeRenamedEvent(Guid entityTypeId, string name, Guid eventId)
        {
            EntityTypeId = entityTypeId;
            EventId = eventId;
            Name = name;
        }

        public string Name { get; }
        public Guid EntityTypeId { get; }
        public Guid EventId { get; }
    }
}