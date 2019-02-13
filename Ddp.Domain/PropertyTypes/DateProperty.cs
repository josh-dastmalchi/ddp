using System;

namespace Ddp.Domain.PropertyTypes
{
    public class DateProperty
    {
        public string Name { get; set; }
        public string MinimumValue { get; set; }
        public string MaximumValue { get; set; }
        public bool IsRequired { get; set; }
    }
}