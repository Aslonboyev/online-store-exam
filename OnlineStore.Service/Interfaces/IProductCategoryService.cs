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
    public interface IProductCategoryService
    {
        Task<BaseResponse<ProductCategory>> CreateAsync(ProductCategoryCreationDTO entity);

        Task<BaseResponse<ProductCategory>> UpdateAsync(long id, ProductCategoryCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<ProductCategory, bool>> expression);

        Task<BaseResponse<ProductCategory>> GetAsync(Expression<Func<ProductCategory, bool>> expression);

        Task<BaseResponse<IEnumerable<ProductCategory>>> GetAllAsync(Expression<Func<ProductCategory, bool>> expression = null);
    }
}
