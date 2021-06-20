namespace DesignPatterns._1_DecoratorCompositeAdapter.Decorator
{
    public sealed class EventNotificationUserService : UserServiceDecorator
    {
        private readonly IEventBus _eventBus;

        public EventNotificationUserService(IUserService userService, IEventBus eventBus)
            : base(userService)
        {
            _eventBus = eventBus;
        }

        public override DomainUser Create(string firstName, string lastName)
        {
            var newUser = base.Create(firstName, lastName);
            if (newUser is DomainUser)
            {
                var @event = new UserCreatedEvent(newUser);
                _eventBus.PublishEvent(@event);
            }

            return newUser;
        }

        public override bool UpdateUserActivity(DomainUser user)
        {
            var userUpdated = base.UpdateUserActivity(user);
            if (userUpdated)
            {
                var @event = new UserActivityUpdatedEvent(user);
                _eventBus.PublishEvent(@event);
            }

            return userUpdated;
        }
    }
}
