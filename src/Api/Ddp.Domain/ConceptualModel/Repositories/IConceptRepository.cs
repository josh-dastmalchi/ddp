﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Ddp.Domain.ConceptualModel.Concepts;

namespace Ddp.Domain.ConceptualModel.Repositories
{
    public interface IConceptRepository
    {
        Task<Concept> Get(Guid conceptId, CancellationToken cancellationToken = default(CancellationToken));
        Task<Concept> GetByName(string name, CancellationToken cancellationToken = default(CancellationToken));
        Task Create(Concept concept, CancellationToken cancellationToken = default(CancellationToken));
        Task Update(Concept concept, CancellationToken cancellationToken = default(CancellationToken));
    }
}