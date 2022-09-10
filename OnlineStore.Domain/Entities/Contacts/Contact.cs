using StoreProject.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Domain.Entities.Contacts
{
    public class Contact : Auditable
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public string TelegramName { get; set; }

        [Required]
        public string InstagramName { get; set; }
    }
}
