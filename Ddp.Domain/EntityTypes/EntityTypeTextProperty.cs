using Ddp.Domain.PropertyTypes;
using System;

namespace Ddp.Domain.EntityTypes
{
    public class EntityTypeTextProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public TextProperty DateProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}