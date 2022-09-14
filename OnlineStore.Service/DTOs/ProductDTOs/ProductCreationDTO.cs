using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Service.DTOs.ProductDTOs
{
    public class ProductCreationDTO
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
