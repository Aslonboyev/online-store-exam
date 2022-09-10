using OnlineStore.Domain.Common.Responses;
using OnlineStore.Domain.Entities.Orders;
using OnlineStore.Domain.Entities.Users;
using OnlineStore.Service.DTOs.OrderDTOs;
using OnlineStore.Service.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
