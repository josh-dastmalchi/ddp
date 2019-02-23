using System;
using Ddp.Domain.EntityRelationshipModel.PropertyTypes;

namespace Ddp.Domain.EntityRelationshipModel.EntityTypes
{
    public class EntityTypeDateTimeProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public DateTimeProperty DateTimeProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}