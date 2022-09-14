using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories.BaseRepositories;
using OnlineStore.Domain.Entities.Products;

namespace OnlineStore.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
    }
}
