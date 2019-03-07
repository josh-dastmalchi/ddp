using System;

namespace Ddp.Domain.EntityRelationshipModel.PropertyTypes
{
    public class IntegerProperty
    {
        public Guid IntegerPropertyId { get; set; }
        public string Name { get; set; }
        public int? MinimumValue { get; set; }
        public int? MaximumValue { get; set; }
        public bool IsRequired { get; set; }
    }
}
