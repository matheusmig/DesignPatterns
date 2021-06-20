using Microsoft.Extensions.Caching.Memory;

namespace DesignPatterns._1_DecoratorCompositeAdapter.Composite
{
    public class CachedUserRepository : UserRepositoryDecorator
    {
        private readonly IMemoryCache _memoryCache;

        public CachedUserRepository(IUserRepository userRepository, IMemoryCache memoryCache)
            : base(userRepository)
        {
            _memoryCache = memoryCache;
        }

        public override DataUser GetById(int userId)
        {
            return _memoryCache.GetOrCreate(userId, _ => base.GetById(userId));
        }
    }
}
