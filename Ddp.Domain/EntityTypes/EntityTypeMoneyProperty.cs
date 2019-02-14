using Ddp.Domain.PropertyTypes;
using System;

namespace Ddp.Domain.EntityTypes
{
    public class EntityTypeMoneyProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public MoneyProperty MoneyProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}