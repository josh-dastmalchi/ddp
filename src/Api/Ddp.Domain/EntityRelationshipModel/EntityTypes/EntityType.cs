using System;
using System.Collections.Generic;
using Ddp.Domain.EntityRelationshipModel.Events;

namespace Ddp.Domain.EntityRelationshipModel.EntityTypes
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
                Apply(new EntityTypeRenamedEvent(EntityTypeId,newName, GuidComb.Generate()));
            }
        }

        protected void When(EntityTypeRenamedEvent @event)
        {
            Name = @event.Name;
        }
       
    }
}