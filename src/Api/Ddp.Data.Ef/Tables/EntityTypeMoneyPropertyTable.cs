using System;

namespace Ddp.Data.Ef.Tables
{
    public class EntityTypeMoneyPropertyTable
    {
        public Guid EntityTypeMoneyPropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }
        public decimal? MinimumValue { get; set; }
        public decimal? MaximumValue { get; set; }
        public bool IsRequired { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
