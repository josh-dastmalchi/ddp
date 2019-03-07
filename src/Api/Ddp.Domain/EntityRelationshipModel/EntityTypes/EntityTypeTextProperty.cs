using System;
using Ddp.Domain.EntityRelationshipModel.PropertyTypes;

namespace Ddp.Domain.EntityRelationshipModel.EntityTypes
{
    public class EntityTypeTextProperty : EventSourcedEntity
    {
        public Guid EntityTypeTextPropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public TextProperty TextProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
