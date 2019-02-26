using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class RelationshipRenamedEvent : IDomainEvent
    {
        public RelationshipRenamedEvent(Guid relationshipId, string name, Guid eventId)
        {
            RelationshipId = relationshipId;
            Name = name;
            EventId = eventId;
        }

        public Guid RelationshipId { get; }
        public string Name { get; }
        public Guid EventId { get; }
    }
}