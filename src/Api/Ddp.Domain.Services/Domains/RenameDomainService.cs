using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.Domains.Repositories;

namespace Ddp.Domain.Services.Domains
{
    public class RenameDomainService
    {
        private readonly IDomainRepository _domainRepository;

        public RenameDomainService(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public async Task Rename(Domain.Domains.Domain domain, string newName, CancellationToken cancellationToken)
        {
            var existing = await _domainRepository.GetByName(newName, cancellationToken);
            if (existing != null && existing.DomainId != domain.DomainId)
            {
                throw new DomainValidationException($"A domain named {newName} already exists.");
            }
            domain.Rename(newName);
        }
    }
}
