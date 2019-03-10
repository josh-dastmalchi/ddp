using System;

namespace Ddp.Data.Ef.Tables
{
    public class ConceptAttributeTable
    {
        public Guid ConceptAttributeId { get; set; }
        public Guid ConceptId { get; set; }
        public string Name { get; set; }
    }
}
