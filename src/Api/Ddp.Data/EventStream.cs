using System.Collections.Generic;
using Ddp.Domain;

namespace Ddp.Data
{
    public class EventStream
    {
        public EventStream(IEnumerable<IDomainEvent> domainEvents, int streamVersion)
        {
            DomainEvents = domainEvents;
            StreamVersion = streamVersion;
        }
        public IEnumerable<IDomainEvent> DomainEvents { get; }
        public int StreamVersion { get; }
    }
}