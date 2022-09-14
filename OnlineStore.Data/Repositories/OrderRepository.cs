using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories.BaseRepositories;
using OnlineStore.Domain.Entities.Orders;

namespace OnlineStore.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
    }
}
