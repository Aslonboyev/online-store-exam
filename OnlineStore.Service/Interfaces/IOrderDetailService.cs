using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Orders;
using OnlineStore.Service.DTOs.CategoryDTOs;
using OnlineStore.Service.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Interfaces
{
    public interface IOrderDetailService
    {
        Task<BaseResponse<OrderDetail>> CreateAsync(OrderDetailCreationDTO entity);

        Task<BaseResponse<OrderDetail>> UpdateAsync(long id, OrderDetailCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<OrderDetail, bool>> expression);

        Task<BaseResponse<OrderDetail>> GetAsync(Expression<Func<OrderDetail, bool>> expression);

        Task<BaseResponse<IEnumerable<OrderDetail>>> GetAllAsync(Expression<Func<OrderDetail, bool>> expression = null);
    }
}
