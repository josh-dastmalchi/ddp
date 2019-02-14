using System;
using Ddp.Domain.PropertyTypes;

namespace Ddp.Domain.EntityTypes
{
    public class EntityTypeDurationProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public DurationProperty DurationProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}