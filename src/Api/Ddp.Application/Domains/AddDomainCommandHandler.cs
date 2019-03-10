using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.Domains.Repositories;

namespace Ddp.Application.Domains
{
    public class AddDomainCommandHandler : TransactedCommandHandler<AddDomainCommand>
    {
        private readonly IDomainRepository _domainRepository;

        public AddDomainCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        protected override async Task HandleTransacted(AddDomainCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            var domain = new Domain.Domains.Domain(command.DomainId, command.Name);
            await _domainRepository.Create(domain, cancellationToken);
        }
    }
}