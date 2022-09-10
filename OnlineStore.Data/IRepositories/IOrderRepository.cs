using OnlineStore.Data.IRepositories.IBaseRepositories;
using OnlineStore.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
