using System;

namespace Ddp.Domain.EntityRelationshipModel.PropertyTypes
{
    public class TextProperty
    {
        public Guid TextPropertyId { get; set; }
        public string Name { get; set; }
        public int? MinimumLength { get; set; }
        public int? MaximumLength { get; set; }
        public bool IsRequired { get; set; }
        public string RegularExpressionValidator { get; set; }
    }
}
