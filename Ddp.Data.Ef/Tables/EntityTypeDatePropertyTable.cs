using System;

namespace Ddp.Data.Ef.Tables
{
    public class EntityTypeDatePropertyTable
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public int? MaximumAllowed { get; set; }
    }
}
