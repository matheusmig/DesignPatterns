using System;

namespace DesignPatterns._1_DecoratorCompositeAdapter
{
    public sealed class UserActivityUpdatedEvent : IEvent
    {
        public DomainUser User { get; }

        Guid IEvent.Id { get; } = Guid.NewGuid();

        public UserActivityUpdatedEvent(DomainUser user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
