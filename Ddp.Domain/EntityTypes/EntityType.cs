using System;
using System.Collections.Generic;
using Ddp.Domain.Events;

namespace Ddp.Domain.EntityTypes
{
    public class EntityType : EventSourcedEntity
    {
        public EntityType(Guid entityTypeId, string name)
        {
            EntityTypeId = entityTypeId;
            Name = name;
        }

        public EntityType(IEnumerable<IDomainEvent> eventStream, int streamVersion) : base(eventStream, streamVersion) { }

        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }

        public void Rename(string newName)
        {
            if (newName != Name)
            {
                Apply(new EntityTypeRenamedEvent(GuidComb.Generate(), newName));
            }
        }

        protected void When(EntityTypeRenamedEvent @event)
        {
            Name = @event.Name;
        }
       
    }
}