using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._1_DecoratorCompositeAdapter
{
    public interface IUserRepository
    {
        DataUser GetById(int userId);
        DataUser Create(DomainUser user);
        bool UpdateUserActivity(int userId, DateTimeOffset lastActivity);
    }
}
