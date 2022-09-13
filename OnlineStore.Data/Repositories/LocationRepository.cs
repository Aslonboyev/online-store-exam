using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories.BaseRepositories;
using OnlineStore.Domain.Entities.Locations;

namespace OnlineStore.Data.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
    }
}
