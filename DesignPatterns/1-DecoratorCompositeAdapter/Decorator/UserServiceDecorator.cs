namespace DesignPatterns._1_DecoratorCompositeAdapter.Decorator
{
    public abstract class UserServiceDecorator : IUserService
    {
        private readonly IUserService _userService;

        public UserServiceDecorator(IUserService userService)
        {
            _userService = userService;
        }

        public virtual DomainUser Create(string firstName, string lastName)
        {
            return _userService.Create(firstName, lastName);
        }

        public virtual DomainUser Get(int userId)
        { 
            return _userService.Get(userId);
        }

        public virtual bool UpdateUserActivity(DomainUser user)
        {
            return _userService.UpdateUserActivity(user);
        }
    }
}
