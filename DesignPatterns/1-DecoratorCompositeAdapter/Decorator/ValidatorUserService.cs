using System;

namespace DesignPatterns._1_DecoratorCompositeAdapter.Decorator
{
    public class ValidatorUserService : UserServiceDecorator
    {

        public ValidatorUserService(IUserService userService)
            : base(userService)
        {
        }

        public override DomainUser Get(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("User Id must be positive");

            return base.Get(userId);
        }

        public override DomainUser Create(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException("FirstName must have a value");

            if (firstName.Length < 3)
                throw new ArgumentNullException("FirstName must have at least 3 characters");

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("LastName must have a value");

            if (lastName.Length < 3)
                throw new ArgumentNullException("LastNAme must have at least 3 characters");

            return Create(firstName, lastName);
        }

        public override bool UpdateUserActivity(DomainUser user)
        {
            _ = user ?? throw new ArgumentNullException("FirstName must have a value");

            return base.UpdateUserActivity(user);
        }
    }
}
