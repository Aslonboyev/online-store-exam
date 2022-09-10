using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Discounts;
using OnlineStore.Service.DTOs.CategoryDTOs;
using OnlineStore.Service.DTOs.DiscountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Interfaces
{
    public interface IDiscountService
    {
        Task<BaseResponse<Discount>> CreateAsync(DiscountCreationDTO entity);

        Task<BaseResponse<Discount>> UpdateAsync(long id, DiscountCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Discount, bool>> expression);

        Task<BaseResponse<Discount>> GetAsync(Expression<Func<Discount, bool>> expression);

        Task<BaseResponse<IEnumerable<Discount>>> GetAllAsync(Expression<Func<Discount, bool>> expression = null);
    }
}
