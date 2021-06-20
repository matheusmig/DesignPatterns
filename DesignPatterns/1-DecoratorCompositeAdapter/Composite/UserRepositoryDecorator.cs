using System;

namespace DesignPatterns._1_DecoratorCompositeAdapter.Composite
{
    public class UserRepositoryDecorator : IUserRepository
    {
        private readonly IUserRepository _userRepository;

        public UserRepositoryDecorator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public virtual DataUser Create(DomainUser user)
        {
            return _userRepository.Create(user);
        }

        public virtual DataUser GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public virtual bool UpdateUserActivity(int userId, DateTimeOffset lastActivity)
        {
            return _userRepository.UpdateUserActivity(userId, lastActivity);
        }
    }
}
