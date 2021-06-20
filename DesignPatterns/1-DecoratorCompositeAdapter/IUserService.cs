namespace DesignPatterns._1_DecoratorCompositeAdapter
{
    public interface IUserService
    {
        DomainUser Get(int userId);
        DomainUser Create(string firstName, string lastName);
        bool UpdateUserActivity(DomainUser user);
    }
}
