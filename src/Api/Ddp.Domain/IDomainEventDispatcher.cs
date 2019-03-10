using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ddp.Domain
{
    public interface IDomainEventDispatcher
    {
        Task QueueEvent(IDomainEvent @event);
        Task QueueEvents(IEnumerable<IDomainEvent> @event);
        Task DispatchTransactedEvents();
        Task DispatchNonTransactedEvents();
    }
}
