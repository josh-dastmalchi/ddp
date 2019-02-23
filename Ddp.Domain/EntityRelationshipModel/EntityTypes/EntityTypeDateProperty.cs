using System;
using Ddp.Domain.EntityRelationshipModel.PropertyTypes;

namespace Ddp.Domain.EntityRelationshipModel.EntityTypes
{
    public class EntityTypeDateProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public DateProperty DateProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}