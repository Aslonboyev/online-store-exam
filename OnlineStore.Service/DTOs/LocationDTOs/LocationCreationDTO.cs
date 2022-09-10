using OnlineStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.DTOs.LocationDTOs
{
    public class LocationCreationDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public Region Region { get; set; }

        [Required]
        public DateTime WorkStartedAt { get; set; }

        [Required]
        public DateTime WorkEndedAt { get; set; }
    }
}
