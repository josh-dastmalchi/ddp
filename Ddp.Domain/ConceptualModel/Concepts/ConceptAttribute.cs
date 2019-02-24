using System;
using Ddp.Domain.ConceptualModel.Events;

namespace Ddp.Domain.ConceptualModel.Concepts
{
    public class ConceptAttribute : EventSourcedEntity
    {
        public ConceptAttribute(Guid conceptAttributeId, Guid conceptId, string name)
        {
            Apply(new ConceptAttributeAddedEvent(conceptAttributeId, conceptId, name, GuidComb.Generate()));
        }
        public Guid ConceptAttributeId { get; private set; }
        public Guid ConceptId { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public void Rename(string newName)
        {
            if (Name != newName)
            {
                Apply(new ConceptAttributeRenamedEvent(ConceptAttributeId, newName, GuidComb.Generate()));
            }
        }
        protected void When(ConceptAttributeAddedEvent @event)
        {
            ConceptAttributeId = @event.ConceptAttributeId;
            ConceptId = @event.ConceptId;
            Name = @event.Name;
            IsActive = true;
        }

        protected void When(ConceptAttributeRemovedEvent @event)
        {
            IsActive = false;
        }

        protected void When(ConceptAttributeRenamedEvent @event)
        {
            Name = @event.Name;
        }
    }
}