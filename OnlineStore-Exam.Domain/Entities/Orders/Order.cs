using StoreProject.Domain.Common;
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

        [Required]
        public long LocationId { get; set; }
    }
}
