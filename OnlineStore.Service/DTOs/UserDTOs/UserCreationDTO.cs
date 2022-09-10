using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.DTOs.UserDTOs
{
    public class UserCreationDTO
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

        [Required, StringLength(maximumLength: 100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
