using OnlineStore.Data.IRepositories.IBaseRepositories;
using OnlineStore.Domain.Entities.Orders;

namespace OnlineStore.Data.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
