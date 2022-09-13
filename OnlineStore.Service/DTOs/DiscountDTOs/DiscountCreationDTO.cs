using OnlineStore.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Service.DTOs.DiscountDTOs
{
    public class DiscountCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal DiscountPercentage { get; set; }

        [Required]
        public ICollection<Product> Products { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
