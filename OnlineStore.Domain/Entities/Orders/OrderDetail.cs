using OnlineStore.Domain.Common;
using OnlineStore.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Entities.Orders
{
    public class OrderDetail : Auditable
    {
        [Required]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int ProductCount { get; set; }

        [Required]
        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
