using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
