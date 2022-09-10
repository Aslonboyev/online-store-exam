using StoreProject.Domain.Common;

namespace StoreProject.Domain.Entities.ManyToMany
{
    public class OrderDiscount : BaseEntity
    {
        public long OrderId { get; set; }

        public long DiscountId { get; set; }
    }
}
