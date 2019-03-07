using System;

namespace Ddp.Data.Ef.Tables
{
    public class EntityTypeDateTimePropertyTable
    {
        public Guid EntityTypeDateTimePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? MinimumValue { get; set; }
        public DateTimeOffset? MaximumValue { get; set; }
        public bool IsRequired { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
