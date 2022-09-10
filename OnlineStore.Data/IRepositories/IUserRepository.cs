using OnlineStore.Data.IRepositories.IBaseRepositories;
using OnlineStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
