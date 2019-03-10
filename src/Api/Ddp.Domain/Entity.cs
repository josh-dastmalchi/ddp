using System.Collections.Generic;

namespace Ddp.Domain
{
    public abstract class Entity
    {
        protected readonly List<IDomainEvent> MutatingEvents;

        protected Entity()
        {
            MutatingEvents = new List<IDomainEvent>();
        }

        protected void Apply(IDomainEvent e)
        {
            MutatingEvents.Add(e);
        }

        public IEnumerable<IDomainEvent> GetMutatingEvents()
        {
            return MutatingEvents.ToArray();
        }
    }
}
