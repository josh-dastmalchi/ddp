using System;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Data.Ef.Tables;
using Ddp.Domain;
using Ddp.Domain.ConceptualModel.Concepts;
using Ddp.Domain.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ddp.Data.Ef.Repositories
{
    public class DomainRepository : IDomainRepository
    {
        private readonly IDdpContextProvider _ddpContextProvider;
        private readonly IEventStore _eventStore;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public DomainRepository(
            IDdpContextProvider ddpContextProvider, 
            IEventStore eventStore,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _ddpContextProvider = ddpContextProvider;
            _eventStore = eventStore;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task<Domain.Domains.Domain> Get(Guid domainId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();
            var domainTable = await context.DomainTables.FindAsync(domainId);
            if (domainTable == null)
            {
                return null;
            }

            var stream = await _eventStore.GetEventStreamFor<Domain.Domains.Domain>(domainId, cancellationToken: cancellationToken);

            var domain = new Domain.Domains.Domain(stream.DomainEvents, stream.StreamVersion);

            return domain;
        }

        public async Task<Domain.Domains.Domain> GetByName(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();
            var domainTable = await context.DomainTables.SingleOrDefaultAsync(c => c.Name == name, cancellationToken);
            if (domainTable == null)
            {
                return null;
            }

            var stream = await _eventStore.GetEventStreamFor<Domain.Domains.Domain>(domainTable.DomainId, cancellationToken: cancellationToken);

            var domain = new Domain.Domains.Domain(stream.DomainEvents, stream.StreamVersion);

            return domain;
        }

        public async Task Create(Domain.Domains.Domain domain, CancellationToken cancellationToken)
        {
            var context = await _ddpContextProvider.Get();

            var domainTable = new DomainTable
            {
                DomainId = domain.DomainId,
                Name = domain.Name
            };

            await context.DomainTables.AddAsync(domainTable, cancellationToken);
            await _eventStore.StoreEventsFor(domain, domain.DomainId, cancellationToken);
            await _domainEventDispatcher.QueueEvents(domain.GetMutatingEvents());
        }
    }
}