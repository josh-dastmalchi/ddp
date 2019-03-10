using System;

namespace Ddp.Application.Domains
{
    public class AddDomainCommand : ICommand
    {
        public AddDomainCommand(Guid domainId, string name)
        {
            DomainId = domainId;
            Name = name;
        }

        public Guid DomainId { get; }
        public string Name { get; }
    }
}