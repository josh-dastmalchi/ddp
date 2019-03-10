using System;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain;

namespace Ddp.Data
{
    public interface IEventStore
    {
        Task<EventStream> GetEventStreamFor<T>(Guid entityId, int? version = null, CancellationToken cancellationToken = default(CancellationToken)) where T : EventSourcedEntity;
        Task<EventStream> GetEventStreamFor<T>(int entityId, int? version = null, CancellationToken cancellationToken = default(CancellationToken)) where T : EventSourcedEntity;
        Task<EventStream> GetEventStreamFor<T>(string entityId, int? version = null, CancellationToken cancellationToken = default(CancellationToken)) where T : EventSourcedEntity;

        Task StoreEventsFor<T>(T entity, Guid entityId, CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity;

        Task StoreEventsFor<T>(T entity, int entityId, CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity;

        Task StoreEventsFor<T>(T entity, string entityId, CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity;
    }
}
