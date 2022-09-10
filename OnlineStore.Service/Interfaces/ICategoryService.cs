using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Service.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<BaseResponse<Category>> CreateAsync(CategoryCreationDTO entity);

        Task<BaseResponse<Category>> UpdateAsync(long id, CategoryCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Category, bool>> expression);

        Task<BaseResponse<Category>> GetAsync(Expression<Func<Category, bool>> expression);

        Task<BaseResponse<IEnumerable<Category>>> GetAllAsync(Expression<Func<Category, bool>> expression = null);
    }
}
