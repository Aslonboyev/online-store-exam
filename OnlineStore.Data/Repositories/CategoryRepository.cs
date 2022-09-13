using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories.BaseRepositories;
using OnlineStore.Domain.Entities.Categories;

namespace OnlineStore.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
    }
}
