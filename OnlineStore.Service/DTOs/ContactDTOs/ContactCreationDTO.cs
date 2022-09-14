using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Service.DTOs.ContactDTOs
{
    public class ContactCreationDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public string TelegramName { get; set; }

        [Required]
        public string InstagramName { get; set; }

        [Required]
        public string FacebookName { get; set; }
    }
}
