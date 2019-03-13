using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.Domains.Repositories;

namespace Ddp.Domain.Services.Domains
{
    public class AddDomainService
    {
        private readonly IDomainRepository _domainRepository;

        public AddDomainService(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public async Task Add(Domain.Domains.Domain domain, CancellationToken cancellationToken)
        {
            var existing = _domainRepository.GetByName(domain.Name, cancellationToken);

            if (existing != null)
            {
                throw new DomainValidationException($"A domain named {domain.Name} already exists.");
            }

            await _domainRepository.Create(domain, cancellationToken);
        }
    }
}