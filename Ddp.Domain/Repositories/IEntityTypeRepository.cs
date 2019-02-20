using Ddp.Domain.EntityTypes;
using System;
using System.Threading.Tasks;

namespace Ddp.Domain.Repositories
{
    public interface IEntityTypeRepository
    {
        Task<EntityType> Get(Guid entityTypeId);
        Task Create(EntityType entityType);
        Task Update(EntityType entityType);
    }
}