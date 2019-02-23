using System;

namespace Ddp.Domain.EntityRelationshipModel.PropertyTypes
{
    public class DurationProperty
    {
        public Guid DurationPropertyId { get; set; }
        public string Name { get; set; }
        public TimeSpan? MinimumValue { get; set; }
        public TimeSpan? MaximumValue { get; set; }
        public bool IsRequired { get; set; }
    }
}
