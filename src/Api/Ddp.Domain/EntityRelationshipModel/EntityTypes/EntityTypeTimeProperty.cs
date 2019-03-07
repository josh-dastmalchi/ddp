using System;
using Ddp.Domain.EntityRelationshipModel.PropertyTypes;

namespace Ddp.Domain.EntityRelationshipModel.EntityTypes
{
    public class EntityTypeTimeProperty : EventSourcedEntity
    {
        public Guid EntityTypeTimePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public TimeProperty TimeProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
