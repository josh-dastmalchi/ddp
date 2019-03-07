using System;

namespace Ddp.Data.Ef.Tables
{
    public class EntityTypeDatePropertyTable
    {
        public Guid EntityTypeDatePropertyId { get; set; }
        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }
        public string MinimumValue { get; set; }
        public string MaximumValue { get; set; }
        public bool IsRequired { get; set; }
        public int? MaximumAllowed { get; set; }

    }
}
