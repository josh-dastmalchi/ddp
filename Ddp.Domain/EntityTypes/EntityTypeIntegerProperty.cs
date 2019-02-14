using Ddp.Domain.PropertyTypes;
using System;

namespace Ddp.Domain.EntityTypes
{
    public class EntityTypeIntegerProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public IntegerProperty IntegerProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}