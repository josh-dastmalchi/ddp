using System;
using System.Collections.Generic;

namespace Ddp.Domain.EntityRelationshipModel.Constraints
{
    public class UniquenessConstraint
    {
        public UniquenessConstraint(Guid uniquenessConstraintId, string name, int numberAllowed, List<Guid> entityPropertyId)
        {
            UniquenessConstraintId = uniquenessConstraintId;
            Name = name;
            NumberAllowed = numberAllowed;
            EntityPropertyId = entityPropertyId;
        }

        public Guid UniquenessConstraintId { get; }
        public string Name { get; }
        public List<Guid> EntityPropertyId { get; }
        public int NumberAllowed { get; }
    }
}
