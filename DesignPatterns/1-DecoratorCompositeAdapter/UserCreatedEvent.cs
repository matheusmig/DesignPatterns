using System;

namespace DesignPatterns._1_DecoratorCompositeAdapter
{
    public sealed class UserCreatedEvent : IEvent
    {
        public DomainUser User { get; }

        Guid IEvent.Id { get; } = Guid.NewGuid();

        public UserCreatedEvent(DomainUser user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
