using Ddp.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ddp.Data
{
    public interface IEventStore
    {
        Task<List<IDomainEvent>> GetEventsFor<T>(Guid entityId, int? version = null);
        Task<List<IDomainEvent>> GetEventsFor<T>(int entityId, int? version = null);
        Task<List<IDomainEvent>> GetEventsFor<T>(string entityId, int? version = null);

        Task StoreEventsFor<T>(Guid entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents);
        Task StoreEventsFor<T>(int entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents);
        Task StoreEventsFor<T>(string entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents);
    }
}
