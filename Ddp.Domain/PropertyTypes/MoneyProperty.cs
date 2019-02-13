using System;
using System.Collections.Generic;
using System.Text;

namespace Ddp.Domain.PropertyTypes
{
    public class MoneyProperty
    {
        public Guid MoneyPropertyId { get; set; }
        public string Name { get; set; }
        public decimal? MinimumValue { get; set; }
        public decimal? MaximumValue { get; set; }
        public bool IsRequired { get; set; }
    }
}
