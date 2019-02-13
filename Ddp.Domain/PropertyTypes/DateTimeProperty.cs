using System;

namespace Ddp.Domain.PropertyTypes
{
    public class DateTimeProperty
    {
        public Guid DateTimePropertyId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? MinimumValue { get; set; }
        public DateTimeOffset? MaximumValue { get; set; }
        public bool IsRequired { get; set; }
    }
}