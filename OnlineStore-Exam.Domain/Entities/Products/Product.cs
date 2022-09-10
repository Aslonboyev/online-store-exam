using StoreProject.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Domain.Entities.Products
{
    public class Product : Auditable
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public long ProductCategoryId { get; set; }
    }
}
