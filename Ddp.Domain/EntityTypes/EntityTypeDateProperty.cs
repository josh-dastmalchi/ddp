using System;
using Ddp.Domain.PropertyTypes;

namespace Ddp.Domain.EntityTypes
{
    public class EntityTypeDateProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public DateProperty DateProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}