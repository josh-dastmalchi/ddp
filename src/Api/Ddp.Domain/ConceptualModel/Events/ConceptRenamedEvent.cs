using System;

namespace Ddp.Domain.ConceptualModel.Events
{
    public class ConceptRenamedEvent : IDomainEvent
    {
        public ConceptRenamedEvent(Guid conceptId, string name, Guid eventId)
        {
            ConceptId = conceptId;
            Name = name;
            EventId = eventId;
        }

        public Guid ConceptId { get; }
        public string Name { get; }
        public Guid EventId { get; }
    }
}