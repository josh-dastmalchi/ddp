using System;
using Ddp.Domain.PropertyTypes;

namespace Ddp.Domain.EntityTypes
{
    public class EntityTypeTimeProperty : EventSourcedEntity
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public TimeProperty TimeProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}