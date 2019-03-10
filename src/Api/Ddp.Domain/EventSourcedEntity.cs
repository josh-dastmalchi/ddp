using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ddp.Domain
{
    public abstract class EventSourcedEntity
    {
        protected readonly List<IDomainEvent> MutatingEvents;

        protected EventSourcedEntity()
        {
            MutatingEvents = new List<IDomainEvent>();
        }

        protected EventSourcedEntity(IEnumerable<IDomainEvent> eventStream, int streamVersion)
        {
            foreach (var e in eventStream)
            {
                DoWhen(e);
            }

            UnmutatedVersion = streamVersion;
        }

        public int UnmutatedVersion { get; }

        public IEnumerable<IDomainEvent> GetMutatingEvents()
        {
            return MutatingEvents.ToArray();
        }
        
        private void DoWhen(IDomainEvent e)
        {
            var method = GetType().GetMethod("When", BindingFlags.Instance | BindingFlags.NonPublic, null,
                new[] { e.GetType() }, null);
            if (method == null)
            {
                throw new NotImplementedException($"A domain event handler was not found for {e.GetType().Name}");
            }
            method.Invoke(this, new object[] { e });
        }
        protected void Apply(IDomainEvent e)
        {
            MutatingEvents.Add(e);
            DoWhen(e);
        }
    }
}
