using StoreProject.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace StoreProject.Domain.Entities.Categories
{
    public class ProductCategory : Auditable
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
