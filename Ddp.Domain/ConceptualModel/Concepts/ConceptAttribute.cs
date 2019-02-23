using System;

namespace Ddp.Domain.ConceptualModel.Concepts
{
    public class ConceptAttribute
    {
        
        public Guid ConceptAttributeId { get; private set; }
        public Guid ConceptId { get; private set; }
        public string Name { get; private set; }
    }
}
