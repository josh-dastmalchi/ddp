using System;

namespace Ddp.Application.ConceptualModel
{
    public class AddConceptCommand : ICommand
    {
        public AddConceptCommand(Guid conceptId, Guid domainId,  string name, string description)
        {
            ConceptId = conceptId;
            DomainId = domainId;
            Name = name;
            Description = description;
        }

        public Guid ConceptId { get; }
        public Guid DomainId { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
