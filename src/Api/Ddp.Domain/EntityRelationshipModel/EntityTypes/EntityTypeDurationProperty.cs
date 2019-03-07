using System;
using Ddp.Domain.EntityRelationshipModel.PropertyTypes;

namespace Ddp.Domain.EntityRelationshipModel.EntityTypes
{
    public class EntityTypeDurationProperty : EventSourcedEntity
    {
        public Guid EntityTypeDurationPropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public DurationProperty DurationProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
