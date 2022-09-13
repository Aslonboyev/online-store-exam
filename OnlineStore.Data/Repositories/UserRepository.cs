using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories.BaseRepositories;
using OnlineStore.Domain.Entities.Users;

namespace OnlineStore.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
    }
}
