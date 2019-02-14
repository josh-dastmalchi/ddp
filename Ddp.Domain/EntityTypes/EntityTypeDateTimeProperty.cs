using Ddp.Domain.PropertyTypes;
using System;

namespace Ddp.Domain.EntityTypes
{
    public class EntityTypeDateTimeProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public DateTimeProperty DateTimeProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}