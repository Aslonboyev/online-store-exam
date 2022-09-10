using StoreProject.Domain.Common;

namespace StoreProject.Domain.Entities.ManyToMany
{
    public class DiscountProduct : BaseEntity
    {
        public long DiscountId { get; set; }

        public long ProductId { get; set; }
    }
}