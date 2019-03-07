using System;

namespace Ddp.Data.Ef.Tables
{
    public class EntityTypeTimePropertyTable
    {
        public Guid EntityTypeTimePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }
        public TimeSpan? MinimumValue { get; set; }
        public TimeSpan? MaximumValue { get; set; }
        public bool IsRequired { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
