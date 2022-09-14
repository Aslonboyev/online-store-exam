using OnlineStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

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
        public TimeOnly WorkStartedAt { get; set; }

        [Required]
        public TimeOnly WorkEndedAt { get; set; }
    }
}
