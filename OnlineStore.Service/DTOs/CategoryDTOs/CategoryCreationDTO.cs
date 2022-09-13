using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Service.DTOs.CategoryDTOs
{
    public class CategoryCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
