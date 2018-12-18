using ST.Domain.Repository.User;
using ST.Repository;

namespace ST.Infrastructure.Repository.User
{
    public class UserRepository : Repository<Domain.Entities.User>, IUserRepository
    {
    }
}
