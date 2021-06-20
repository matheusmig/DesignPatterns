using Microsoft.Extensions.Logging;
using NSubstitute;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = Substitute.For<ILogger>();

            //1
            _ = new LoggingUserService(
                   new EventNotificationUserService(
                       userService: new UserService(
                           userRepository: new CachingUserRepository(
                               new CompositeUserRepository(new[]
                               {
                                    Substitute.For<IUserRepository>(),
                                    Substitute.For<IUserRepository>()
                               }),
                               new LoggingMemoryCache(Substitute.For<IMemoryCache>(), logger)),
                           userBuilder: Substitute.For<IBuilder<DataUser, DomainUser>>(),
                           systemClock: new SystemClock()),
                       eventBus: new LoggingEventBus(
                           eventBus: new FeatureBasedFactory<IEventBus, EnableNotifications>(
                               Substitute.For<IFeatureToggleService<EnableNotifications>>(),
                               new List<Lazy<IEventBus, bool>>
                               {
                                    new(() => new ConsoleEventBus(), true),
                                    new(() => new NoNotificationEventBus(), false),
                               }).CreateService(),
                           logger)),
                   logger: logger);
        }
    }
}
