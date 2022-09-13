using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Users;
using OnlineStore.Service.DTOs.UserDTOs;
using System.Linq.Expressions;

namespace OnlineStore.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<User>> CreateAsync(UserCreationDTO entity);

        Task<BaseResponse<User>> UpdateAsync(long id, UserCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<User, bool>> expression);

        Task<BaseResponse<User>> GetAsync(Expression<Func<User, bool>> expression);

        Task<BaseResponse<IEnumerable<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null);

        Task<BaseResponse<User>> LogInAsync(string username, string passowrd);
    }
}
