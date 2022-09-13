using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Orders;
using OnlineStore.Service.DTOs.OrderDTOs;
using System.Linq.Expressions;

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
