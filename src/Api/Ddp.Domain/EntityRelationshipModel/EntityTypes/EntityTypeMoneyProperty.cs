using System;
using Ddp.Domain.EntityRelationshipModel.PropertyTypes;

namespace Ddp.Domain.EntityRelationshipModel.EntityTypes
{
    public class EntityTypeMoneyProperty : EventSourcedEntity
    {
        public Guid EntityTypeMoneyPropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public MoneyProperty MoneyProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
