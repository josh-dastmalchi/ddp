using System;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Data.Ef.Tables;
using Ddp.Domain;
using Ddp.Domain.ConceptualModel.Concepts;
using Ddp.Domain.ConceptualModel.Repositories;

namespace Ddp.Data.Ef.Repositories
{
    public class ConceptRepository : IConceptRepository

    {
        private readonly IEventStore _eventStore;
        private readonly IDdpContextProvider _ddpContextProvider;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public ConceptRepository(
            IEventStore eventStore,
            IDdpContextProvider ddpContextProvider, 
            IDomainEventDispatcher domainEventDispatcher)
        {
            _eventStore = eventStore;
            _ddpContextProvider = ddpContextProvider;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task<Concept> Get(Guid conceptId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();
            var conceptTable = await context.ConceptTables.FindAsync(conceptId);
            if (conceptTable == null)
            {
                return null;
            }

            var stream = await _eventStore.GetEventStreamFor<Concept>(conceptId, cancellationToken: cancellationToken);

            var concept = new Concept(stream.DomainEvents, stream.StreamVersion);

            return concept;
        }

        public async Task Create(Concept concept, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();

            var conceptTable = new ConceptTable
            {
                ConceptId = concept.ConceptId,
                Name = concept.Name,
                Description = concept.Description
            };

            await context.ConceptTables.AddAsync(conceptTable, cancellationToken);
            await _eventStore.StoreEventsFor(concept,concept.ConceptId, cancellationToken);
            await _domainEventDispatcher.QueueEvents(concept.GetMutatingEvents());
        }

        public async Task Update(Concept concept, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();

            var existing = await context.FindAsync<ConceptTable>(concept.ConceptId);

            if (existing == null)
            {
                throw new Exception("nope doesn't exist");
            }

            existing.Description = concept.Description;
            existing.Name = concept.Name;

            await context.SaveChangesAsync(cancellationToken);
            await _eventStore.StoreEventsFor(concept, concept.ConceptId, cancellationToken);
            await _domainEventDispatcher.QueueEvents(concept.GetMutatingEvents());
        }
    }
}
