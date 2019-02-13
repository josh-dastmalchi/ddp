using Ddp.Domain.EntityTypes;
using System;
using System.Threading.Tasks;

namespace Ddp.Domain.Repositories
{
    public interface IEntityTypeRepository
    {
        Task<EntityType> Get(Guid entityTypeId);
        Task<EntityType> Create(EntityType entityType);
        Task<EntityType> Update(EntityType entityType);
    }
}