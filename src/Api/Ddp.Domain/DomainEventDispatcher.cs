using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ddp.Domain
{
    // TODO
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        public Task QueueEvent(IDomainEvent @event)
        {
            return Task.CompletedTask;
        }

        public Task QueueEvents(IEnumerable<IDomainEvent> @event)
        {
            return Task.CompletedTask;
        }

        public Task DispatchTransactedEvents()
        {
            return Task.CompletedTask;
        }

        public Task DispatchNonTransactedEvents()
        {
            return Task.CompletedTask;
        }
    }
}