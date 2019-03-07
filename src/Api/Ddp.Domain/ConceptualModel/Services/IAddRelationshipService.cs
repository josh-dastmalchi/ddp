using System;
using System.Threading.Tasks;

namespace Ddp.Domain.ConceptualModel.Services
{
    public interface IAddRelationshipService
    {
        Task AddRelationship(Guid relationshipId, string name, Guid leftSideConceptId, Guid rightSideConceptId);
    }
}