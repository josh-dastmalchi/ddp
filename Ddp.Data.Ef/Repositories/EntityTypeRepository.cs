using System;
using System.Threading.Tasks;
using Ddp.Data.Ef.Tables;
using Ddp.Domain.EntityRelationshipModel.EntityTypes;
using Ddp.Domain.EntityRelationshipModel.Repositories;

namespace Ddp.Data.Ef.Repositories
{
    public class EntityTypeRepository : IEntityTypeRepository
    {
        private readonly IEventStore _eventStore;
        private readonly IDdpContextProvider _ddpContextProvider;

        public EntityTypeRepository(IEventStore eventStore, IDdpContextProvider ddpContextProvider)
        {
            _eventStore = eventStore;
            _ddpContextProvider = ddpContextProvider;
        }

        public async Task<EntityType> Get(Guid entityTypeId)
        {
            var context = await _ddpContextProvider.Get();
            var entityTypeTable = await context.EntityTypeTables.FindAsync(entityTypeId);
            if (entityTypeTable == null)
            {
                return null;
            }

            var stream = await _eventStore.GetEventStreamFor<EntityType>(entityTypeId);

            var entityType = new EntityType(stream.DomainEvents, stream.StreamVersion);

            return entityType;
        }

        public async Task Create(EntityType entityType)
        {
            var entityTypeTable = new EntityTypeTable
            {
                EntityTypeId = entityType.EntityTypeId
            };

            var context = await _ddpContextProvider.Get();

            await context.EntityTypeTables.AddAsync(entityTypeTable);

            await _eventStore.StoreEventsFor<EntityType>(entityType.EntityTypeId, entityType.UnmutatedVersion, entityType.GetPendingEvents());
        }

        public async Task Update(EntityType entityType)
        {
            var context = await _ddpContextProvider.Get();

            var existing = await context.FindAsync<EntityType>(entityType.EntityTypeId);

            if (existing == null)
            {
                throw new Exception("nope doesn't exist");
            }

            await _eventStore.StoreEventsFor<EntityType>(entityType.EntityTypeId, entityType.UnmutatedVersion,
                entityType.GetPendingEvents());
        }
    }
}
