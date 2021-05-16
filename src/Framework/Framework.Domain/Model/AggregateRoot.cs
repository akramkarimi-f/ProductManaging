using System.Collections.Generic;

namespace Framework.Domain.Model
{
    public class AggregateRoot<TKey> : DeletableEntity<TKey>, IAggregateRoot
    {
        private List<IDomainEvent> _uncommittedEvents;
        public IReadOnlyList<IDomainEvent> UncommittedEvents => _uncommittedEvents.AsReadOnly();
        public AggregateRoot()
        {
            _uncommittedEvents = new List<IDomainEvent>();
        }
    }
}