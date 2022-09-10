using StoreProject.Domain.Common;
using StoreProject.Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Domain.Entities.Users
{
    public class User : Auditable
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required, StringLength(maximumLength: 100, MinimumLength = 6)]
        public string Username { get; set; }

        [Required, StringLength(maximumLength: 150, MinimumLength = 6)]
        public string Password { get; set; }

        ICollection<Order> Orders { get; set; }
    }
}
