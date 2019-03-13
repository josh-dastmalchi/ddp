using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ddp.Domain.Domains.Repositories
{
    public interface IDomainRepository
    {
        Task<Domain> Get(Guid domainId, CancellationToken cancellationToken = default(CancellationToken));
        Task<Domain> GetByName(string name, CancellationToken cancellationToken = default(CancellationToken));
        Task Create(Domain domain, CancellationToken cancellationToken = default(CancellationToken));
        
    }
}