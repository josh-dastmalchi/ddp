using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddp.Domain;

namespace Ddp.Data.SqlServer
{
    public class SqlServerEventStore : IEventStore
    {
        public async Task<IDomainEvent> GetEventsFor<T>(Guid entityId, int? version = null)
        {
            return await GetEventsForInternal<T>(entityId.ToString(), version);
        }

        public async Task<IDomainEvent> GetEventsFor<T>(int entityId, int? version = null)
        {
            return await GetEventsForInternal<T>(entityId.ToString(), version);
        }

        public async Task<IDomainEvent> GetEventsFor<T>(string entityId, int? version = null)
        {
            return await GetEventsForInternal<T>(entityId, version);
        }

        private Task<IDomainEvent> GetEventsForInternal<T>(string entityId, int? version = null)
        {
            throw new NotImplementedException();
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

        private Task StoreEventsForInternal<T>(string entityId, int baseVersion, IEnumerable<IDomainEvent> domainEvents)
        {
            throw new NotImplementedException();
        }
    }
}