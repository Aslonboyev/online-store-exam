using OnlineStore.Domain.Common;
using OnlineStore.Domain.Entities.Locations;
using OnlineStore.Domain.Entities.Users;
using OnlineStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Entities.Orders
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
