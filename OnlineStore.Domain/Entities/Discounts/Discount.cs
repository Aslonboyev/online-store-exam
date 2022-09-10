using OnlineStore.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Entities.Discounts
{
    public class Discount : Auditable
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal DiscountPercentage { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
