using System;

namespace Ddp.Data.Ef.Tables
{
    public class EntityTypeIntegerPropertyTable
    {
        public Guid EntityTypeIntegerPropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }
        public int? MinimumValue { get; set; }
        public int? MaximumValue { get; set; }
        public bool IsRequired { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
