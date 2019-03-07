using System;
using System.Threading.Tasks;
using Ddp.Domain.EntityRelationshipModel.EntityTypes;

namespace Ddp.Domain.EntityRelationshipModel.Repositories
{
    public interface IEntityTypeRepository
    {
        Task<EntityType> Get(Guid entityTypeId);
        Task Create(EntityType entityType);
        Task Update(EntityType entityType);
    }
}