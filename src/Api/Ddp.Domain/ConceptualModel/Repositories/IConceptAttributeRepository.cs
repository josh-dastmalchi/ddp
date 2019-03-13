using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.ConceptualModel.Concepts;

namespace Ddp.Domain.ConceptualModel.Repositories
{
    public interface IConceptAttributeRepository
    {
        Task<ConceptAttribute> Get(Guid conceptAttributeId, CancellationToken cancellationToken = default(CancellationToken));
        Task<ConceptAttribute> GetByConceptAndName(Guid conceptId, string name, CancellationToken cancellationToken = default(CancellationToken));
        Task Create(ConceptAttribute conceptAttribute, CancellationToken cancellationToken = default(CancellationToken));
        Task Update(ConceptAttribute conceptAttribute, CancellationToken cancellationToken = default(CancellationToken));
    }
}
