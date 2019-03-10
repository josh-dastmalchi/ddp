using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Data.Ef.Tables;
using Ddp.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ddp.Data.Ef
{
    public class SqlServerEventStore : IEventStore
    {
        private readonly IDdpContextProvider _ddpContextProvider;

        public SqlServerEventStore(IDdpContextProvider ddpContextProvider)
        {
            _ddpContextProvider = ddpContextProvider;
        }

        public async Task<EventStream> GetEventStreamFor<T>(Guid entityId, int? version = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity
        {
            return await GetEventsForInternal<T>(entityId.ToString(), version, cancellationToken);
        }

        public async Task<EventStream> GetEventStreamFor<T>(int entityId, int? version = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity
        {
            return await GetEventsForInternal<T>(entityId.ToString(), version, cancellationToken);
        }

        public async Task<EventStream> GetEventStreamFor<T>(string entityId, int? version = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity
        {
            return await GetEventsForInternal<T>(entityId, version, cancellationToken);
        }

        private async Task<EventStream> GetEventsForInternal<T>(string entityId, int? version = null,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity
        {
            var entityType = EventStoreMapping.GetEntityName<T>();
            if (entityType == null)
            {
                throw new Exception($"Unable to find event store mapping for entity type {typeof(T)}. Did you forget to add an entity binding to the event store mapping?");
            }

            var context = await _ddpContextProvider.Get();
            var query = context.EventTables.Where(x => x.EntityType == entityType && x.EntityId == entityId);
            if (version.HasValue)
            {
                query = query.Where(x => x.Version <= version);
            }

            var eventTables = await query.ToListAsync();

            var allEvents = new List<IDomainEvent>();
            foreach (var eventTable in eventTables)
            {
                var eventType = EventStoreMapping.GetEventType(eventTable.EventType);
                if (eventType == null)
                {
                    throw new Exception($"Unable to find event store mapping for event {eventTable.EventType}. Did you forget to add an event binding to the event store mapping?");
                }

                var materialized = (IDomainEvent)JsonConvert.DeserializeObject(eventTable.EventData, eventType);
                allEvents.Add(materialized);
            }

            return new EventStream(allEvents, eventTables.Max(x => x.Version));
        }

        public async Task StoreEventsFor<T>(T entity, Guid entityId,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity
        {
            await StoreEventsForInternal(entity, entityId.ToString(), cancellationToken);
        }

        public async Task StoreEventsFor<T>(T entity, int entityId,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity
        {
            await StoreEventsForInternal(entity, entityId.ToString(), cancellationToken);
        }

        public async Task StoreEventsFor<T>(T entity, string entityId,
            CancellationToken cancellationToken = default(CancellationToken))
            where T : EventSourcedEntity
        {
            await StoreEventsForInternal(entity, entityId, cancellationToken);
        }

        private async Task StoreEventsForInternal<T>(T entity, string entityId,
            CancellationToken cancellationToken = default(CancellationToken)) where T : EventSourcedEntity
        {
            var entityType = EventStoreMapping.GetEntityName<T>();
            if (entityType == null)
            {
                throw new Exception("Unknown entity");
            }

            var context = await _ddpContextProvider.Get();

            // Verify concurrency - for now just throw on breaking
            var latestEvent = await context.EventTables.Where(x => x.EntityType == entityType && x.EntityId == entityId)
                .OrderByDescending(x => x.Version).Select(x => x.Version).FirstOrDefaultAsync();
            if (entity.UnmutatedVersion > latestEvent)
            {
                throw new Exception("Tried to save an entity but someone else got here first.");
            }

            var next = 1;
            var domainEvents = entity.GetMutatingEvents();
            foreach (var domainEvent in domainEvents)
            {
                var eventType = EventStoreMapping.GetEventName(domainEvent.GetType());
                if (eventType == null)
                {
                    throw new Exception("Unknown event");
                }

                var eventData = await SerializeEventData(domainEvent);
                var eventTable = new EventTable
                {
                    EventId = domainEvent.EventId,
                    EntityType = entityType,
                    EntityId = entityId,
                    Version = entity.UnmutatedVersion + next,
                    EventData = eventData,
                    EventType = eventType
                };

                context.EventTables.Add(eventTable);
                next++;
            }

            await context.SaveChangesAsync(cancellationToken);

        }

        // TODO: Move to injected service?
        private Task<string> SerializeEventData(object obj)
        {
            return Task.FromResult(JsonConvert.SerializeObject(obj));
        }
    }
}
