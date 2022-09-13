using OnlineStore.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Entities.Categories
{
    public class Category : Auditable
    {
        [Required]
        public string Name { get; set; }
    }
}
