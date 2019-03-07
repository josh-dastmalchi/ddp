using System;

namespace Ddp.Application.ConceptualModel
{
    public class AddConceptCommand : ICommand
    {
        public AddConceptCommand(Guid conceptId, string name, string description)
        {
            ConceptId = conceptId;
            Name = name;
            Description = description;
        }

        public Guid ConceptId { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
