using System.ComponentModel.DataAnnotations;

namespace Project_OData.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public virtual SubCategory? SubCategory { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; } = [];
    }                                                                    
}
