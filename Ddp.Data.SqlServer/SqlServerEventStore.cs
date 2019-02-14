﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ddp.Data.Ef.Tables;
using Ddp.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ddp.Data.Ef
{
    public class SqlServerEventStore : IEventStore
    {
        private readonly IContextProvider _contextProvider;

        public SqlServerEventStore(IContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public async Task<List<IDomainEvent>> GetEventsFor<T>(Guid entityId, int? version = null)
        {
            return await GetEventsForInternal<T>(entityId.ToString(), version);
        }

        public async Task<List<IDomainEvent>> GetEventsFor<T>(int entityId, int? version = null)
        {
            return await GetEventsForInternal<T>(entityId.ToString(), version);
        }

        public async Task<List<IDomainEvent>> GetEventsFor<T>(string entityId, int? version = null)
        {
            return await GetEventsForInternal<T>(entityId, version);
        }

        private async Task<List<IDomainEvent>> GetEventsForInternal<T>(string entityId, int? version = null)
        {
            var entityType = EventStoreMapping.GetEntityName<T>();
            if (entityType == null)
            {
                throw new Exception("entity not found");
            }
            var context = await _contextProvider.Get();
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
                    throw new Exception("unknown event type");
                }

                var materialized = (IDomainEvent)JsonConvert.DeserializeObject(eventTable.EventData, eventType);
                allEvents.Add(materialized);
            }

            return allEvents;
        }

        public async Task StoreEventsFor<T>(Guid entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents)
        {
            await StoreEventsForInternal<T>(entityId.ToString(), baseVersion, domainEvents);
        }

        public async Task StoreEventsFor<T>(int entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents)
        {
            await StoreEventsForInternal<T>(entityId.ToString(), baseVersion, domainEvents);
        }

        public async Task StoreEventsFor<T>(string entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents)
        {
            await StoreEventsForInternal<T>(entityId, baseVersion, domainEvents);
        }

        private async Task StoreEventsForInternal<T>(string entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents)
        {
            var entityType = EventStoreMapping.GetEntityName<T>();
            if (entityType == null)
            {
                throw new Exception("Unknown entity");
            }

            var context = await _contextProvider.Get();

            // Verify concurrency - for now just throw on breaking
            var latestEvent = await context.EventTables.Where(x => x.EntityType == entityType && x.EntityId == entityId)
                .OrderByDescending(x => x.Version).Select(x => x.Version).FirstOrDefaultAsync();
            if (baseVersion > latestEvent)
            {
                throw new Exception("Tried to save an entity but someone else got here first.");
            }

            var next = 1;
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
                    Version = baseVersion + next,
                    EventData = eventData,
                    EventType = eventType
                };

                context.EventTables.Add(eventTable);
                next++;
            }
        }

        private Task<string> SerializeEventData(object obj)
        {
            return Task.FromResult(JsonConvert.SerializeObject(obj));
        }
    }
}