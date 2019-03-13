using System;
using System.Collections.Generic;
using Ddp.Domain.ConceptualModel.Events;

namespace Ddp.Domain.ConceptualModel.Concepts
{
    public class ConceptAttribute : EventSourcedEntity
    {
        public ConceptAttribute(Guid conceptAttributeId, Guid conceptId, string name)
        {
            Apply(new ConceptAttributeAddedEvent(conceptAttributeId, conceptId, name, GuidComb.Generate()));
        }

        public ConceptAttribute(IEnumerable<IDomainEvent> eventStream, int streamVersion)  :base(eventStream, streamVersion) {  }
        public Guid ConceptAttributeId { get; private set; }
        public Guid ConceptId { get; private set; }
        public string Name { get; private set; }
        public bool IsRequired { get; private set; }
        public bool IsActive { get; private set; }

        public void Rename(string newName)
        {
            Apply(new ConceptAttributeRenamedEvent(ConceptAttributeId, newName, GuidComb.Generate()));
        }

        public void MakeRequired()
        {
            Apply(new ConceptAttributeMadeRequiredEvent(ConceptAttributeId, GuidComb.Generate()));
        }

        public void MakeNotRequired()
        {
            Apply(new ConceptAttributeMadeNotRequiredEvent(ConceptAttributeId, GuidComb.Generate()));
        }

        protected void When(ConceptAttributeAddedEvent @event)
        {
            ConceptAttributeId = @event.ConceptAttributeId;
            ConceptId = @event.ConceptId;
            Name = @event.Name;
            IsActive = true;
            IsRequired = false;
        }

        protected void When(ConceptAttributeRemovedEvent @event)
        {
            IsActive = false;
        }

        protected void When(ConceptAttributeRenamedEvent @event)
        {
            Name = @event.Name;
        }

        protected void When(ConceptAttributeMadeRequiredEvent @event)
        {
            IsRequired = true;
        }

        protected void When(ConceptAttributeMadeNotRequiredEvent @event)
        {
            IsRequired = false;
        }
    }
}
