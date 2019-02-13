using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ddp.Domain
{
    public abstract class EventSourcedEntity : Entity
    {
        protected EventSourcedEntity()
        {
            this._mutatingEvents = new List<IDomainEvent>();
        }

        protected EventSourcedEntity(IEnumerable<IDomainEvent> eventStream, int streamVersion)
            : this()
        {
            foreach (var e in eventStream)
            {
                DoWhen(e);
            }

            UnmutatedVersion = streamVersion;
        }

        readonly List<IDomainEvent> _mutatingEvents;

        protected int UnmutatedVersion { get; }

        public IEnumerable<IDomainEvent> GetPendingEvents()
        {
            return _mutatingEvents.ToArray();
        }

        private void DoWhen(IDomainEvent e)
        {
            var method = GetType().GetMethod("When", BindingFlags.Instance | BindingFlags.NonPublic, null,
                new[] {e.GetType()}, null);
            if (method == null)
            {
                throw new NotImplementedException($"A domain event handler was not found for {e.GetType().Name}");
            }
            method.Invoke(this, new object[] { e });
        }
        protected void Apply(IDomainEvent e)
        {
            _mutatingEvents.Add(e);
            DoWhen(e);
        }
    }
}