using System;
using System.Collections.Generic;
using Ddp.Domain.Domains.Events;

namespace Ddp.Domain.Domains
{
    public class Domain : EventSourcedEntity
    {
        public Domain(Guid domainId, string name)
        {
            Apply(new DomainAddedEvent(domainId, name, GuidComb.Generate()));
        }

        public Domain(IEnumerable<IDomainEvent> eventStream, int streamVersion) : base(eventStream, streamVersion) {  }
        public Guid DomainId { get; private set; }
        public string Name { get; private set; }

        public void Rename(string newName)
        {
            if (newName != Name)
            {
                Apply(new DomainRenamedEvent(DomainId, newName, GuidComb.Generate()));
            }
        }
        protected void When(DomainAddedEvent @event)
        {
            DomainId = @event.DomainId;
            Name = @event.Name;
        }

        protected void When(DomainRenamedEvent @event)
        {
            Name = @event.Name;
        }
    }
}