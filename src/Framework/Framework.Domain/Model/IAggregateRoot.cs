using System.Collections.Generic;

namespace Framework.Domain.Model
{
    public interface IAggregateRoot
    {
        IReadOnlyList<IDomainEvent> UncommittedEvents { get; }
    }
}