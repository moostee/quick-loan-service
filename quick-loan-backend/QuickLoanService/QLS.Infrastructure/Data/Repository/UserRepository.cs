namespace QLS.Infrastructure.Data.Repository;
using QLS.Domain;

internal class UserRepository : Repository<User, int>, IUserRepository
{
    public UserRepository(QLSContext context) : base(context)
    {
    }
}
