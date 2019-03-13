using System;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Data.Ef.Tables;
using Ddp.Domain;
using Ddp.Domain.ConceptualModel.Concepts;
using Ddp.Domain.ConceptualModel.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ddp.Data.Ef.Repositories
{
    public class ConceptAttributeRepository : IConceptAttributeRepository
    {
        private readonly IEventStore _eventStore;
        private readonly IDdpContextProvider _ddpContextProvider;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public ConceptAttributeRepository
        (
            IEventStore eventStore,
            IDdpContextProvider ddpContextProvider,
            IDomainEventDispatcher domainEventDispatcher)
        {
            _eventStore = eventStore;
            _ddpContextProvider = ddpContextProvider;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task<ConceptAttribute> Get(Guid conceptAttributeId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();
            var conceptAttributeTable = await context.ConceptAttributeTables.FindAsync(conceptAttributeId);
            if (conceptAttributeTable == null)
            {
                return null;
            }

            var stream = await _eventStore.GetEventStreamFor<ConceptAttribute>(conceptAttributeId, cancellationToken: cancellationToken);

            var concept = new ConceptAttribute(stream.DomainEvents, stream.StreamVersion);

            return concept;
        }

        public async Task<ConceptAttribute> GetByConceptAndName(Guid conceptId, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();
            var conceptAttributeTable = await context.ConceptAttributeTables.SingleOrDefaultAsync(c => c.ConceptId == conceptId && c.Name == name, cancellationToken);
            if (conceptAttributeTable == null)
            {
                return null;
            }

            var stream = await _eventStore.GetEventStreamFor<ConceptAttribute>(conceptAttributeTable.ConceptId, cancellationToken: cancellationToken);

            var concept = new ConceptAttribute(stream.DomainEvents, stream.StreamVersion);

            return concept;
        }

        public async Task Create(ConceptAttribute conceptAttribute, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();

            var conceptAttributeTable = new ConceptAttributeTable
            {
                ConceptAttributeId =  conceptAttribute.ConceptAttributeId,
                ConceptId = conceptAttribute.ConceptId,
                Name = conceptAttribute.Name,
            };

            await context.ConceptAttributeTables.AddAsync(conceptAttributeTable, cancellationToken);
            await _eventStore.StoreEventsFor(conceptAttribute, conceptAttribute.ConceptId, cancellationToken);
            await _domainEventDispatcher.QueueEvents(conceptAttribute.GetMutatingEvents());
        }

        public async Task Update(ConceptAttribute conceptAttribute, CancellationToken cancellationToken = default(CancellationToken))
        {
            var context = await _ddpContextProvider.Get();

            var existing = await context.FindAsync<ConceptAttributeTable>(conceptAttribute.ConceptAttributeId);

            if (existing == null)
            {
                throw new EntityNotFoundException("nope doesn't exist");
            }

            existing.ConceptId = conceptAttribute.ConceptId;
            existing.Name = conceptAttribute.Name;

            await context.SaveChangesAsync(cancellationToken);
            await _eventStore.StoreEventsFor(conceptAttribute, conceptAttribute.ConceptId, cancellationToken);
            await _domainEventDispatcher.QueueEvents(conceptAttribute.GetMutatingEvents());
        }
    }
}
