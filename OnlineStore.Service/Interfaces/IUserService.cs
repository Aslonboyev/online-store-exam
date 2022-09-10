using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Users;
using OnlineStore.Service.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<User>> CreateAsync(UserCreationDTO entity);

        Task<BaseResponse<User>> UpdateAsync(long id, UserCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<User, bool>> expression);
     
        Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression);

        Task<BaseResponse<IEnumerable<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null);

        Task<BaseResponse<bool>> LogInAsync(string username, string passowrd);
    }
}
