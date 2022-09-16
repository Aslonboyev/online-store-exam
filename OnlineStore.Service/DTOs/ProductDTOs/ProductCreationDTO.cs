using Microsoft.AspNetCore.Http;
using OnlineStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Service.DTOs.ProductDTOs
{
    public class ProductCreationDTO
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public long CategoryId { get; set; }

        public ProductParameter ProductParameter { get; set; }

        public IFormFile? FormFile { get; set; }
    }
}
