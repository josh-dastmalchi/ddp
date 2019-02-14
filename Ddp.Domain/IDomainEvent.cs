using System;

namespace Ddp.Domain
{
    public interface IDomainEvent
    {
        Guid EventId { get; }
    }
}