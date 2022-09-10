using StoreProject.Domain.Common;

namespace StoreProject.Domain.Entities.ManyToMany
{
    public class OrderProduct : BaseEntity
    {
        public long OrderId { get; set; }

        public long ProductId { get; set; }
    }
}