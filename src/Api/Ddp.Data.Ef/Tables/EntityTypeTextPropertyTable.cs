using System;

namespace Ddp.Data.Ef.Tables
{
    public class EntityTypeTextPropertyTable
    {
        public Guid EntityTypeTextPropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }
        public int? MinimumLength { get; set; }
        public int? MaximumLength { get; set; }
        public bool IsRequired { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
