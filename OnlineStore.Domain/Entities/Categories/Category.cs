using StoreProject.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Domain.Entities.Categories
{
    public class Category : Auditable
    { 
        [Required]
        public string Name { get; set; }
    }
}
