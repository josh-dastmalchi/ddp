using System;
using System.Collections.Generic;
using System.Text;

namespace Ddp.Domain.PropertyTypes
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
