using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories.BaseRepositories;
using OnlineStore.Domain.Entities.Contacts;

namespace OnlineStore.Data.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
    }
}
