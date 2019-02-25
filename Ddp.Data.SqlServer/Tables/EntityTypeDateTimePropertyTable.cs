using System;

namespace Ddp.Data.Ef.Tables
{
    public class EntityTypeDateTimePropertyTable
    {
        public Guid EntityTypeDateTimePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
