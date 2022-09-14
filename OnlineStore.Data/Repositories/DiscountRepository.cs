using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories.BaseRepositories;
using OnlineStore.Domain.Entities.Discounts;

namespace OnlineStore.Data.Repositories
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
    }
}
