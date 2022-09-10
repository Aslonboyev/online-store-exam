using StoreProject.Domain.Common;
using StoreProject.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Domain.Entities.Locations
{
    public class Location : Auditable
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
