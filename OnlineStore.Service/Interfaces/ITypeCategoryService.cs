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
    public interface ITypeCategoryService
    {
        Task<BaseResponse<TypeCategory>> CreateAsync(CategoryCreationDTO entity);

        Task<BaseResponse<TypeCategory>> UpdateAsync(long id, CategoryCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<TypeCategory, bool>> expression);

        Task<BaseResponse<TypeCategory>> GetAsync(Expression<Func<TypeCategory, bool>> expression);

        Task<BaseResponse<IEnumerable<TypeCategory>>> GetAllAsync(Expression<Func<TypeCategory, bool>> expression = null);
    }
}
