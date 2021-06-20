using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns._1_DecoratorCompositeAdapter.Composite
{
    public sealed class CompositeUserRepository : IUserRepository
    {
        private readonly IEnumerable<IUserRepository> _userRepositories;

        public CompositeUserRepository(IEnumerable<IUserRepository> userRepositories)
        {
            _userRepositories = userRepositories;
        }

        DataUser IUserRepository.Create(DomainUser user)
        {
            return _userRepositories
                .Select(r => r.Create(user))
                .Where(u => u is not null)
                .FirstOrDefault();
        }

        DataUser IUserRepository.GetById(int userId)
        {
            return _userRepositories
                .Select(r => r.GetById(userId))
                .Where(u => u is not null)
                .FirstOrDefault();
        }

        bool IUserRepository.UpdateUserActivity(int userId, DateTimeOffset lastActivity)
        {
            return _userRepositories.All(r => r.UpdateUserActivity(userId, lastActivity));
        }
    }

}
