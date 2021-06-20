using Microsoft.Extensions.Logging;
using System;

namespace DesignPatterns._1_DecoratorCompositeAdapter.Decorator
{
    public class LoggingUserService : UserServiceDecorator
    {
        private readonly ILogger _logger;

        public LoggingUserService(IUserService userService, ILogger logger)
            : base(userService)
        {
            _logger = logger;
        }

        public override DomainUser Get(int userId)
        {
            try
            {
                _logger.LogInformation($"Getting user with id {userId}...");

                return base.Get(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user");
                throw;
            }
        }

        public override DomainUser Create(string firstName, string lastName)
        {
            try
            {
                var result = base.Create(firstName, lastName);
                _logger.LogInformation($"Created user with id {result.Id}...");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                throw;
            }
        }

        public override bool UpdateUserActivity(DomainUser user)
        {
            try
            {
                _logger.LogInformation($"Updating user activity with id {user.Id}...");

                return base.UpdateUserActivity(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user activity");
                throw;
            }
        }
    }
}
