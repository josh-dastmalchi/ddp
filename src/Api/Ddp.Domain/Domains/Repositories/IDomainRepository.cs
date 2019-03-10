using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ddp.Domain.Domains.Repositories
{
    public interface IDomainRepository
    {
        Task Create(Domain domain, CancellationToken cancellationToken);
        
    }
}