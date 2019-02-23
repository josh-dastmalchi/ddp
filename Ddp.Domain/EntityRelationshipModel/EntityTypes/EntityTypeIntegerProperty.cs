using System;
using Ddp.Domain.EntityRelationshipModel.PropertyTypes;

namespace Ddp.Domain.EntityRelationshipModel.EntityTypes
{
    public class EntityTypeIntegerProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public IntegerProperty IntegerProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}