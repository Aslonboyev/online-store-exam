using OnlineStore.Domain.Enums;
using OnlineStore.Service.DTOs.DiscountDTOs;
using OnlineStore.Service.DTOs.LocationDTOs;
using OnlineStore.Service.DTOs.ProductDTOs;
using OnlineStore.Service.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.DTOs.OrderDTOs
{
    public class OrderCreationDTO
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

        [Required]
        public ICollection<ProductCreationDTO> Products { get; set; }

        public ICollection<DiscountCreationDTO> Discounts { get; set; }
    }
}
