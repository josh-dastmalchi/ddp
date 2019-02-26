using System;
using System.Threading.Tasks;

namespace Ddp.Domain.ConceptualModel.Services
{
    public interface IAddConceptService
    {
        Task AddConcept(Guid conceptId, string name);
    }
}