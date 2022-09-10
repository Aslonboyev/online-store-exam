using StoreProject.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Domain.Common
{
    public abstract class Auditable : BaseEntity
    {
        public ItemState ItemState { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
            ItemState = ItemState.Active;
        }

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
            ItemState = ItemState.Updated;
        }

        public void Delete()
        {
            UpdatedAt = DateTime.UtcNow;
            ItemState = ItemState.Deleted;
        }
    }
}
