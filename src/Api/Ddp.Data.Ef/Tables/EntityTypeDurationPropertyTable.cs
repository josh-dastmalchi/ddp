using System;

namespace Ddp.Data.Ef.Tables
{
    public class EntityTypeDurationPropertyTable
    {
        public Guid EntityTypeDurationPropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }
        public TimeSpan? MinimumValue { get; set; }
        public TimeSpan? MaximumValue { get; set; }
        public bool IsRequired { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
