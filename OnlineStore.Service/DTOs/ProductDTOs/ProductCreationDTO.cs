using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
