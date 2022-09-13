using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Orders;
using OnlineStore.Service.DTOs.OrderDTOs;
using System.Linq.Expressions;

namespace OnlineStore.Service.Interfaces
{
    public interface IOrderService
    {
        Task<BaseResponse<Order>> CreateAsync(OrderCreationDTO entity);

        Task<BaseResponse<Order>> UpdateAsync(long id, OrderCreationDTO entity);

        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Order, bool>> expression);

        Task<BaseResponse<Order>> GetAsync(Expression<Func<Order, bool>> expression);

        Task<BaseResponse<IEnumerable<Order>>> GetAllAsync(Expression<Func<Order, bool>> expression = null);
    }
}
