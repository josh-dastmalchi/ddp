using System.Threading;
using System.Threading.Tasks;
using Ddp.Data.Ef.Tables;
using Ddp.Domain;
using Ddp.Domain.Domains.Repositories;

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