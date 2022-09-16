using OnlineStore.Domain.Common;
using OnlineStore.Domain.Entities.Categories;
using OnlineStore.Domain.Entities.Discounts;
using OnlineStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Entities.Products
{
    public class Product : Auditable
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public ProductParameter ProductParameter { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public long? DiscountId { get; set; }
        public Discount Discount { get; set; }

        [Required]
        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
