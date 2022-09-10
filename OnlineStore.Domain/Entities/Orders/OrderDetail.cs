using StoreProject.Domain.Common;
using StoreProject.Domain.Entities.Orders;
using StoreProject.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
