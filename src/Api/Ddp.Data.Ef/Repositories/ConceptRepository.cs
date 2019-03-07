using System;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Data.Ef.Tables;
using Ddp.Domain.ConceptualModel.Concepts;
using Ddp.Domain.ConceptualModel.Repositories;

namespace Ddp.Data.Ef.Repositories
{
    public class ConceptRepository : IConceptRepository

    {
        private readonly IEventStore _eventStore;
        private readonly IDdpContextProvider _ddpContextProvider;

        public ConceptRepository(IEventStore eventStore, IDdpContextProvider ddpContextProvider)
        {
            _eventStore = eventStore;
            _ddpContextProvider = ddpContextProvider;
        }

        public async Task<Concept> Get(Guid entityTypeId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();
            var entityTypeTable = await context.EntityTypeTables.FindAsync(entityTypeId);
            if (entityTypeTable == null)
            {
                return null;
            }

            var stream = await _eventStore.GetEventStreamFor<Concept>(entityTypeId);

            var entityType = new Concept(stream.DomainEvents, stream.StreamVersion);

            return entityType;
        }

        public async Task Create(Concept concept, CancellationToken cancellationToken = default(CancellationToken))
        {
            var conceptTable = new ConceptTable
            {
                ConceptId = concept.ConceptId
            };

            var context = await _ddpContextProvider.Get();

            await context.ConceptTables.AddAsync(conceptTable, cancellationToken);

            await _eventStore.StoreEventsFor<Concept>(concept.ConceptId, concept.UnmutatedVersion, concept.GetPendingEvents());
        }

        public async Task Update(Concept concept, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();

            var existing = await context.FindAsync<Concept>(concept.ConceptId);

            if (existing == null)
            {
                throw new Exception("nope doesn't exist");
            }

            await _eventStore.StoreEventsFor<Concept>(concept.ConceptId, concept.UnmutatedVersion,
                concept.GetPendingEvents());
        }
    }
}
