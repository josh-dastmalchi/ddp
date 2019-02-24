﻿using System;
using System.Collections.Generic;
using Ddp.Domain.ConceptualModel.Events;

namespace Ddp.Domain.ConceptualModel.Concepts
{
    public class Concept :EventSourcedEntity
    {
        public Concept(Guid conceptId, string name, string description)
        {
            Apply(new ConceptAddedEvent(conceptId, name, description,GuidComb.Generate()));
        }

        public Concept(IEnumerable<IDomainEvent> eventStream, int streamVersion) : base(eventStream, streamVersion) { }
        public Guid ConceptId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public bool IsActive { get; private set; }
        protected void When(ConceptAddedEvent @event)
        {
            ConceptId = @event.ConceptId;
            Name = @event.Name;
            Description = @event.Description;
            IsActive = true;
        }

        protected void When(ConceptRemovedEvent @event)
        {
            IsActive = false;
        }
        protected void When(ConceptRenamedEvent @event)
        {
            Name = @event.Name;
        }

        protected void When(ConceptDescriptionChangedEvent @event)
        {
            Description = @event.Description;
        }
    }
}