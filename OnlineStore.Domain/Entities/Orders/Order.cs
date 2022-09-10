using OnlineStore.Domain.Entities.Orders;
using StoreProject.Domain.Common;
using StoreProject.Domain.Entities.Locations;
using StoreProject.Domain.Entities.Users;
using StoreProject.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        [Required]
        public DeleveryState DeleveryState { get; set; }

        [Required]
        public UserOpinion UserOpinion { get; set; }

        [Required]
        public decimal Total { get; set; }
        
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }

        [Required]
        public long LocationId { get; set; }
        public Location Location { get; set; }

        ICollection<OrderDetail> Details { get; set; }
    }
}
