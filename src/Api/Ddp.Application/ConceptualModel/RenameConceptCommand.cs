using System;

namespace Ddp.Application.ConceptualModel
{
    public class RenameConceptCommand : ICommand
    {
        public RenameConceptCommand(Guid conceptId, string name)
        {
            ConceptId = conceptId;
            Name = name;
        }

        public Guid ConceptId { get; }
        public string Name { get; }
    }
}
