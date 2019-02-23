using System;
using Ddp.Domain.ConceptualModel.Events;

namespace Ddp.Domain.ConceptualModel.Concepts
{
    public class Concept :EventSourcedEntity
    {
        public Concept(Guid conceptId, string name)
        {
            Apply(new ConceptCreatedEvent(conceptId, name, GuidComb.Generate()));
        }

        public Guid ConceptId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected void When(ConceptCreatedEvent @event)
        {
            ConceptId = @event.TopLevelNounId;
            Name = @event.Name;
        }
    }
}