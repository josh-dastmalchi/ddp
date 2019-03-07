using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddp.Domain;

namespace Ddp.Data
{
    public interface IEventStore
    {
        Task<EventStream> GetEventStreamFor<T>(Guid entityId, int? version = null) where T : EventSourcedEntity;
        Task<EventStream> GetEventStreamFor<T>(int entityId, int? version = null) where T : EventSourcedEntity;
        Task<EventStream> GetEventStreamFor<T>(string entityId, int? version = null) where T : EventSourcedEntity;

        Task StoreEventsFor<T>(Guid entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents)
            where T : EventSourcedEntity;

        Task StoreEventsFor<T>(int entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents)
            where T : EventSourcedEntity;

        Task StoreEventsFor<T>(string entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents)
            where T : EventSourcedEntity;
    }
}