using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Data.Ef;
using Microsoft.EntityFrameworkCore;

namespace Ddp.ReadModels.ConceptualModel
{
    public class GetConceptsForDomainQueryHandler : IQueryHandler<GetConceptsForDomainQuery, GetConceptsForDomainReadModel>
    {
        private readonly IDdpContextProvider _ddpContextProvider;

        public GetConceptsForDomainQueryHandler(IDdpContextProvider ddpContextProvider)
        {
            _ddpContextProvider = ddpContextProvider;
        }

        public async Task<GetConceptsForDomainReadModel> Handle(GetConceptsForDomainQuery query,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var ddpContext = await _ddpContextProvider.Get();
            var readModel = new GetConceptsForDomainReadModel
            {
                Concepts = await ddpContext.ConceptTables.Where(x => x.DomainId == query.DomainId).Select(x =>
                    new GetConceptsForDomainReadModelConcept
                    {
                        ConceptId = x.ConceptId,
                        Description = x.Description,
                        Name = x.Name
                    }).ToListAsync(cancellationToken: cancellationToken)
            };

            return readModel;
        }
    }
}